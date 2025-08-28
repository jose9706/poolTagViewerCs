using poolViewer.PoolHandling;

namespace poolViewer;

public class Recorder(IList<PoolTagInfo> listToRecord)
{
    public void TakeSnapshot()
    {
        if (listToRecord.Count != 0 && _maxItems >= listToRecord.Count)
        {
            _snapShots.Add(new List<PoolTagInfo>(listToRecord));
        }
        else
        {
            
            MessageBox.Show($"Trying to record too many items. Max allowed is {_maxItems}, input list has {listToRecord.Count}" ,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    public void SaveSnapshotToFile(string fileName)
    {
        throw new NotImplementedException();
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

    private readonly IList<List<PoolTagInfo>> _snapShots = new List<List<PoolTagInfo>>();
    private int _maxItems = 100;
}