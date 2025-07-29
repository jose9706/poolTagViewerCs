using System.Runtime.InteropServices;

namespace poolConsole;

[StructLayout(LayoutKind.Sequential)]
public struct SystemBasicInformation
{
    public uint Reserved;
    public uint TimerResolution;
    public uint PageSize;
    public uint NumberOfPhysicalPages;
    public uint LowestPhysicalPageNumber;
    public uint HighestPhysicalPageNumber;
    public uint AllocationGranularity;
    public IntPtr MinimumUserModeAddress;
    public IntPtr MaximumUserModeAddress;
    public IntPtr ActiveProcessorsAffinityMask;
    public byte NumberOfProcessors;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SystemPoolTagInformation
{
    public ulong Count;
    public SystemPoolTag* TagInfo; // Use a pointer to SYSTEM_POOLTAG instead of a fixed-size buffer  
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SystemPoolTag
{
    [StructLayout(LayoutKind.Explicit)]
    public struct TagUnion
    {
        [FieldOffset(0)]
        public fixed byte Tag[4];

        [FieldOffset(0)]
        public uint TagUlong;
    }

    public TagUnion Tag;
    public uint PagedAllocs;
    public uint PagedFrees;
    public UIntPtr PagedUsed;
    public uint NonPagedAllocs;
    public uint NonPagedFrees;
    public UIntPtr NonPagedUsed;
}

