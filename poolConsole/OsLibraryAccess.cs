using System.Runtime.InteropServices;
namespace poolConsole;

public enum NTSTATUS
{
    NT_SUCCESS = 0x0,
}

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
        IntPtr SystemInformation,
        uint SystemInformationLength,
        out uint ReturnLength
    );

    public static bool IsSuccess(int status) => status == 0;
}