namespace poolViewer.PoolHandling;

public class Snapshot
{
    public readonly DateTime snapShotTime;
    public readonly IReadOnlyList<PoolTagInfo> tagInfo;

    public Snapshot(IReadOnlyList<PoolTagInfo> tagInfo)
    {
        ArgumentNullException.ThrowIfNull(tagInfo);

        // We want to store a shallow copy.
        this.tagInfo = new List<PoolTagInfo>(tagInfo);
        snapShotTime = DateTime.UtcNow;
    }
}
