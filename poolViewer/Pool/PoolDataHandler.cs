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
    private readonly nint _outputBuffer = Marshal.AllocHGlobal(OsLibraryAccess.PoolTagSize);

    public List<PoolTagInfo> PoolTags { get; } = [];

    ~PoolDataHandler()
    {
        Marshal.FreeHGlobal(_outputBuffer);
    }

    public void RefreshPoolInfo()
    {
        try
        {
            var status = OsLibraryAccess.NtQuerySystemInformation(
                OsLibraryAccess.SystemInformationClass.SystemPoolTag,
                _outputBuffer,
                OsLibraryAccess.PoolTagSize,
                out var returnLength
            );

            if (OsLibraryAccess.IsSuccess(status))
            {
                _poolTagInfo = Marshal.PtrToStructure<SystemPoolTagInformation>(_outputBuffer);
                //[todo] when we copy this should we just free?
                RefreshStoredData();
            }
            else
            {
                Console.WriteLine($"NtQuerySystemInformation failed. Status: 0x{status:X}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"NtQuerySystemInformation failed. Exception: {ex}");
            throw;
        }
    }

    private void RefreshStoredData()
    {
        unsafe
        {
            var tagsPtr = (SystemPoolTag*)(_outputBuffer + sizeof(ulong));
            PoolTags.Clear();
            for (ulong i = 0; i < _poolTagInfo.Count; i++)
            {
                var tag = tagsPtr[i];
                var tagInfoPaged = new PoolTagInfo
                {
                    // TODO no need to convert to string.
                    Tag = System.Text.Encoding.ASCII.GetString(tag.Tag.Tag, 4),
                    Type = PoolType.Paged,
                    Allocs = (int)(tag.PagedAllocs),
                    Frees = (int)(tag.PagedFrees ),
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