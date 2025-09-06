namespace poolViewer.UnsafePoolHandling;
public enum ChangeType
{
    None,
    Increased,
    Decreased
}

public struct PoolTagInfo
{
    public string Tag { get; set; }

    public PoolType Type { get; set; }

    public uint Allocations { get; set; }

    public uint Frees { get; set; }

    public uint Diff => Allocations - Frees;

    public ulong Bytes { get; set; }

    public ulong Kb => Bytes >> 10;

    public ulong BytesAllocated => Allocations - Frees > 0 ? Bytes / (Allocations - Frees) : 0;

    public string Source { get; set; }

    public string Description { get; set; }

    public ChangeType Change { get; set; }

    public override string ToString() => $"Tag:{Tag},Type:{Type},Allocs:{Allocations},Frees:{Frees},Diff:{Diff},Bytes:{Bytes},KB:{Kb},BAlloc:{BytesAllocated},Source:{Source},Description:{Description},Change:{Change.ToString()}";
}