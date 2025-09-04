namespace poolViewer.UnsafePoolHandling;

public struct PoolTagInfo
{
    public string Tag { get; set; }

    public PoolType Type { get; set; }

    public uint Allocs { get; set; }

    public uint Frees { get; set; }

    public uint Diff => Allocs - Frees;

    public ulong Bytes { get; set; }

    public ulong KB => Bytes >> 10;

    public ulong B_Alloc => Allocs - Frees > 0 ? Bytes / (Allocs - Frees) : 0;

    public string Source { get; set; }

    public string Description { get; set; }

    public ChangeType Change { get; set; }

    public override string ToString() => $"Tag:{Tag},Type:{Type},Allocs:{Allocs},Frees:{Frees},Diff:{Diff},Bytes:{Bytes},KB:{KB},BAlloc:{B_Alloc},Source:{Source},Description:{Description},Change:{Change.ToString()}";
}

public enum ChangeType
{
    None,
    Increased,
    Decreased
}