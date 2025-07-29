namespace poolViewer.Pool;

public class PoolTagInfo
{
    public string Tag { get; set; }

    public PoolType Type { get; set; }

    public int Allocs { get; set; }

    public int Frees { get; set; }

    public int Diff => Allocs - Frees;

    public long Bytes { get; set; }

    public long KB => Bytes / 1024;

    public long B_Alloc => Allocs - Frees > 0 ? Bytes / (Allocs - Frees) : 0;

    public string Source { get; set; }

    public string Description { get; set; }

    public ChangeType Change { get; set; }
}

public enum ChangeType
{
    None,
    Increased,
    Decreased
}