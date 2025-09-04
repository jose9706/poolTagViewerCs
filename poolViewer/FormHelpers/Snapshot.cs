using poolViewer.UnsafePoolHandling;

namespace poolViewer.FormHelpers;

public class Snapshot
{
    public readonly DateTime SnapShotTime;
    public readonly IReadOnlyList<PoolTagInfo> TagInfo;

    public Snapshot(IReadOnlyList<PoolTagInfo> tagInfo)
    {
        ArgumentNullException.ThrowIfNull(tagInfo);

        // We want to store a shallow copy.
        this.TagInfo = new List<PoolTagInfo>(tagInfo);
        SnapShotTime = DateTime.UtcNow;
    }
}
