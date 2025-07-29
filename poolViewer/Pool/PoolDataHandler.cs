using System.Runtime.InteropServices;

namespace poolViewer.Pool;

internal class PoolDataHandler()
{
    private SystemPoolTagInformation _poolTagInfo;
    private readonly nint _outputBuffer = Marshal.AllocHGlobal(OsLibraryAccess.PoolTagSize);

    public SortedDictionary<string, SystemPoolTag> PoolTags { get; } = [];

    ~PoolDataHandler()
    {
        Marshal.FreeHGlobal(_outputBuffer);
    }

    public void ReadPoolInfo()
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
                InsertPoolTags();
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
    public void PrintPoolTag()
    {
        foreach (var systemPoolTag in PoolTags)
        {
            Console.WriteLine(UnsafeStructUtils.FormatPoolTag(systemPoolTag.Value));
        }
    }

    private void InsertPoolTags()
    {
        unsafe
        {
            var tagsPtr = (SystemPoolTag*)(_outputBuffer + sizeof(ulong));
            for (ulong i = 0; i < _poolTagInfo.Count; i++)
            {
                var tag = tagsPtr[i];
                if (!PoolTags.TryAdd(System.Text.Encoding.ASCII.GetString(tag.Tag.Tag, 4), tag))
                {
                    // todo process old and new tag.
                }
            }
        }
    }
}