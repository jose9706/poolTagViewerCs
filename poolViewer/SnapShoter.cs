using System.Text;
using poolViewer.PoolHandling;

namespace poolViewer;

public class SnapShoter(IReadOnlyList<PoolTagInfo> poolInfo)
{
    public void TakeAndStoreSnapshot()
    {
        if (poolInfo.Count != 0 && _maxItems >= poolInfo.Count)
        {
            _snapShots.Add(new Snapshot(poolInfo));
        }
        else
        {
            
            MessageBox.Show($"Trying to record too many items. Max allowed is {_maxItems}, input list has {poolInfo.Count}" ,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Async write for the snapshots.
    /// </summary>
    /// <param name="fileName">File to write to.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if actually saved something.</returns>
    public async Task<bool> SaveSnapshotsToFileAsync(string fileName, CancellationToken cancellationToken = default)
    {
        if (_snapShots.Count == 0)
        {
            MessageBox.Show("No snapshots to save.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }

        // Use UTF8 without BOM for simplicity
        await using var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None,
            bufferSize: 32 * 1024, useAsync: true);
        await using var writer = new StreamWriter(fs, new UTF8Encoding(false));

        foreach (var snap in _snapShots)
        {
            cancellationToken.ThrowIfCancellationRequested();

            foreach (var tag in snap.tagInfo)
            {
                await writer.WriteLineAsync(tag.ToString());
            }
        }
        await writer.FlushAsync(cancellationToken);

        return true;
    }

    public async Task TakeAndSaveSnapShotToFileAsync(string fileName, CancellationToken cancellationToken = default)
    {
        var snap = this.TakeSnapShot();
        if (snap == null) return;

        await using var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None,
            bufferSize: 32 * 1024, useAsync: true);
        await using var writer = new StreamWriter(fs, new UTF8Encoding(false));

        cancellationToken.ThrowIfCancellationRequested();

        await writer.WriteLineAsync($"------SnapshotDate=[{snap.snapShotTime.ToLocalTime()}]------");
        foreach (var tag in snap.tagInfo)
        {
            await writer.WriteLineAsync(tag.ToString());
        }
        await writer.FlushAsync(cancellationToken);
    }
 
    public string GetSnapShotSummary()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Just because at the end of the day you should set your own limits.
    /// </summary>
    /// <param name="newMaxItems">New allowed max items.</param>
    public void OverrideMaxItems(int newMaxItems) => _maxItems = newMaxItems;

    private Snapshot? TakeSnapShot()
    {
        if (poolInfo.Count != 0 && _maxItems >= poolInfo.Count)
        {
            return new Snapshot(poolInfo);
        }
        else
        {
            MessageBox.Show($"Trying to record too many items. Max allowed is {_maxItems}, input list has {poolInfo.Count}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return null;
        }
    }

    private readonly IList<Snapshot> _snapShots = [];
    private int _maxItems = 100;
}