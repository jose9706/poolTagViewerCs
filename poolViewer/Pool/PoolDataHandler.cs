using System.Buffers;
using System.Runtime.InteropServices;

namespace poolViewer.Pool;

public enum PoolType
{
    Paged,
    NonPaged
};

internal class PoolDataHandler()
{
    private SystemPoolTagInformation _poolTagInfo;
    // private readonly nint _outputBuffer = Marshal.AllocHGlobal(OsLibraryAccess.PoolTagSize);
    private readonly byte[] _outputBuffer2 = ArrayPool<byte>.Shared.Rent(OsLibraryAccess.PoolTagSize);

    public List<PoolTagInfo> PoolTags { get; } = [];

    ~PoolDataHandler()
    {
        ArrayPool<byte>.Shared.Return(_outputBuffer2);
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
        unsafe
        {
            var tagsSpan = new Span<SystemPoolTag>(ptr + sizeof(ulong), (int)_poolTagInfo.Count);
            PoolTags.Clear();
            foreach (var tag in tagsSpan)
            {
                var tagInfoPaged = new PoolTagInfo
                {
                    // TODO no need to convert to string.
                    Tag = System.Text.Encoding.ASCII.GetString(tag.Tag.Tag, 4),
                    Type = PoolType.Paged,
                    Allocs = (int)(tag.PagedAllocs),
                    Frees = (int)(tag.PagedFrees),
                    Bytes = (long)(tag.PagedUsed),
                    Source = "Unknown", // Placeholder for source
                    Description = "Unknown" // Placeholder for description
                };

                var tagInfoNonPaged = new PoolTagInfo
                {
                    // TODO no need to convert to string.
                    Tag = System.Text.Encoding.ASCII.GetString(tag.Tag.Tag, 4),
                    Type = PoolType.NonPaged,
                    Allocs = (int)(tag.NonPagedAllocs),
                    Frees = (int)(tag.NonPagedFrees),
                    Bytes = (long)(tag.NonPagedUsed),
                    Source = "Unknown", // Placeholder for source
                    Description = "Unknown" // Placeholder for description
                };

                PoolTags.Add(tagInfoPaged);
                PoolTags.Add(tagInfoNonPaged);
            }
        }
    }
}