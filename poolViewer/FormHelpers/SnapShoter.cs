using System.Text;
using poolViewer.UnsafePoolHandling;

namespace poolViewer.FormHelpers;

public class SnapShoter(IReadOnlyList<PoolTagInfo> poolInfo)
{
    private readonly List<Snapshot> _snapShots = [];
    private int _maxItems = 100;
    
    public int GetSnapshotCount() => this._snapShots.Count;
    
    public bool TakeAndStoreSnapshot()
    {
        if (poolInfo.Count != 0 && _maxItems >= poolInfo.Count)
        {
            _snapShots.Add(new Snapshot(poolInfo));
            return true;
        }

        return false;
    }

    /// <summary>
    /// Async write for the snapshots.
    /// </summary>
    /// <param name="fileName">File to write to.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if actually saved something.</returns>
    public async Task<(bool Success, string? ErrorMessage)> SaveSnapshotsToFileAsync(string fileName, CancellationToken cancellationToken = default)
    {
        if (_snapShots.Count == 0)
        {
            return (false, "Nothing to save.");
        }

        try
        {
            await WriteToFile(fileName, _snapShots, cancellationToken);
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }

        return (true, null);
    }

    public async Task<(bool Success, string? ErrorMessage)> TakeAndSaveSnapShotToFileAsync(string fileName, CancellationToken cancellationToken = default)
    {
        var snapShot = this.TakeSnapShot();
        if (snapShot == null)
        {
            return (false, $"Trying to record too many items. Max allowed is {GetMaxItems()}");
        };

        try
        {
            await WriteToFile(fileName, [snapShot], cancellationToken);
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
        
        return (true, null);
    }

    private static async Task WriteToFile(string fileName, List<Snapshot> snapshots, CancellationToken cancellationToken)
    {
        await using var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None,
            bufferSize: 32 * 1024, useAsync: true);
        await using var writer = new StreamWriter(fs, new UTF8Encoding(false));

        cancellationToken.ThrowIfCancellationRequested();

        foreach (var snapshot in snapshots)
        {
            await writer.WriteLineAsync($"------SnapshotDate=[{snapshot.SnapShotTime.ToLocalTime()}]------");
            foreach (var tag in snapshot.TagInfo)
            {
                await writer.WriteLineAsync(tag.ToString());
            }    
        }
        

        await writer.FlushAsync(cancellationToken);
    }

    /// <summary>
    /// Just because at the end of the day you should set your own limits.
    /// </summary>
    /// <param name="newMaxItems">New allowed max items.</param>
    public void OverrideMaxItems(int newMaxItems) => _maxItems = newMaxItems;

    public int GetMaxItems() => _maxItems;
    
    public void CleanUp()
    {
        _snapShots.Clear();
    }
    
    private Snapshot? TakeSnapShot()
    {
        if (poolInfo.Count != 0 && _maxItems >= poolInfo.Count)
        {
            return new Snapshot(poolInfo);
        }

        return null;
    }
}