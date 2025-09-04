using System.Runtime.InteropServices;

namespace poolViewer.UnsafePoolHandling;

public static partial class OsLibraryAccess
{
    public const int PoolTagSize = 1 << 21; // 2 MB

    public enum SystemInformationClass
    {
        SystemBasicInformation = 0,
        SystemPoolTag = 22,
    }

    [LibraryImport("ntdll.dll")]
    public static partial int NtQuerySystemInformation(
        SystemInformationClass SystemInformationClass,
        nint SystemInformation,
        uint SystemInformationLength,
        out uint ReturnLength
    );

    public static bool IsSuccess(int status) => status == 0;
}