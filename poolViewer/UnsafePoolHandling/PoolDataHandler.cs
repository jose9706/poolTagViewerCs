using System.Buffers;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace poolViewer.UnsafePoolHandling;

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
    private bool _disposed;
    private bool _filterActive;
    private List<Regex>? _filters;

    public List<PoolTagInfo> PoolTags { get; } = [];
    
    public List<Regex>? Filter
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

    public void Dispose()
    {
        if (!_disposed)
        {
            ArrayPool<byte>.Shared.Return(_outputBuffer2);
            _disposed = true;
        }
        GC.SuppressFinalize(this);
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

            if (_filterActive && Filter is { Count: > 0 })
            {
                for (var i = 0; i < Filter.Count; i++)
                {
                    if (Filter[i].IsMatch(tagString))
                    {
                        InsertTag(tagString, tag);
                        break;
                    }
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
            Tag = tagString,
            Type = PoolType.Paged,
            Allocs = (tag.PagedAllocs),
            Frees = (tag.PagedFrees),
            Bytes = (tag.PagedUsed),
            Source = UnknownSource, // Placeholder for source
            Description = UnknownDescription // Placeholder for description
        };

        var tagInfoNonPaged = new PoolTagInfo
        {
            Tag = tagString,
            Type = PoolType.NonPaged,
            Allocs = (tag.NonPagedAllocs),
            Frees = (tag.NonPagedFrees),
            Bytes = (tag.NonPagedUsed),
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
}