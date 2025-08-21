using System.Buffers;
using System.Runtime.InteropServices;

namespace poolViewer.Pool;

public enum PoolType
{
    Paged,
    NonPaged
};

internal class PoolDataHandler() : IDisposable
{
    private const string UnknownSource = "Unknown";
    private const string UnknownDescription = "Unknown";

    private readonly byte[] _outputBuffer2 = ArrayPool<byte>.Shared.Rent(OsLibraryAccess.PoolTagSize);
    private readonly Dictionary<uint, string> _tagStringCache = [];

    private SystemPoolTagInformation _poolTagInfo;
    private bool _disposed = false;
    private bool _filterActive = false;
    private IList<string>? _filters;

    public List<PoolTagInfo> PoolTags { get; } = [];
    
    public IList<string>? Filter
    {
        private get => _filters;
        set
        {
            _filterActive = value is { Count: > 0 };
            _filters = value;
        }
    }

    ~PoolDataHandler()
    {
        if (!_disposed)
        {
            ArrayPool<byte>.Shared.Return(_outputBuffer2);
        }
    }

    public void ClearFilter()
    {
        this._filterActive = false;
        this._filters = null;
    }

    public unsafe void RefreshPoolInfo()
    {
        try
        {
            fixed (byte* ptr = _outputBuffer2)
            {
                var bufferPtr = (nint)ptr;
                var status = OsLibraryAccess.NtQuerySystemInformation(
                    OsLibraryAccess.SystemInformationClass.SystemPoolTag,
                    bufferPtr,
                    OsLibraryAccess.PoolTagSize,
                    out var returnLength
                );
                if (OsLibraryAccess.IsSuccess(status))
                {
                    _poolTagInfo = Marshal.PtrToStructure<SystemPoolTagInformation>(bufferPtr);
                    //[todo] when we copy this should we just free?
                    RefreshStoredData(ptr);
                }
                else
                {
                    Console.WriteLine($"NtQuerySystemInformation failed. Status: 0x{status:X}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"NtQuerySystemInformation failed. Exception: {ex}");
            throw;
        }
    }

    private unsafe void RefreshStoredData(byte* ptr)
    {
        var tagsSpan = new Span<SystemPoolTag>(ptr + sizeof(ulong), (int)_poolTagInfo.Count);
        var expectedCount = (int)_poolTagInfo.Count * 2;
        if (PoolTags.Capacity < expectedCount)
        {
            PoolTags.Capacity = expectedCount;
        }

        PoolTags.Clear();
        foreach (var tag in tagsSpan)
        {
            var tagString = GetTagString(tag.Tag);

            if (_filterActive)
            {
                if (Filter!.Contains(tagString))
                {
                    InsertTag(tagString, tag);    
                }
            }
            else
            {
                InsertTag(tagString, tag);
            }
        }
    }

    private void InsertTag(string tagString, SystemPoolTag tag)
    {
        var tagInfoPaged = new PoolTagInfo
        {
            // TODO no need to convert to string.
            Tag = tagString,
            Type = PoolType.Paged,
            Allocs = (int)(tag.PagedAllocs),
            Frees = (int)(tag.PagedFrees),
            Bytes = (long)(tag.PagedUsed),
            Source = UnknownSource, // Placeholder for source
            Description = UnknownDescription // Placeholder for description
        };

        var tagInfoNonPaged = new PoolTagInfo
        {
            // TODO no need to convert to string.
            Tag = tagString,
            Type = PoolType.NonPaged,
            Allocs = (int)(tag.NonPagedAllocs),
            Frees = (int)(tag.NonPagedFrees),
            Bytes = (long)(tag.NonPagedUsed),
            Source = UnknownSource, // Placeholder for source
            Description = UnknownDescription // Placeholder for description
        };

        PoolTags.Add(tagInfoPaged);
        PoolTags.Add(tagInfoNonPaged);
    }

    private string GetTagString(SystemPoolTag.TagUnion tagUnion)
    {
        if (!_tagStringCache.TryGetValue(tagUnion.TagUlong, out var tagString))
        {
            tagString = string.Create(4, tagUnion.TagUlong, static (span, tagUlong) =>
            {
                span[0] = (char)(tagUlong & 0xFF);
                span[1] = (char)((tagUlong >> 8) & 0xFF);
                span[2] = (char)((tagUlong >> 16) & 0xFF);
                span[3] = (char)((tagUlong >> 24) & 0xFF);
            });
            _tagStringCache[tagUnion.TagUlong] = tagString;
        }
        return tagString;
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            ArrayPool<byte>.Shared.Return(_outputBuffer2);
            _disposed = true;
        }
        GC.SuppressFinalize(this);
    }
}