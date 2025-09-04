namespace poolViewer.FormHelpers;

public class PoolGridRecorder(SnapShoter poolTagRecorder)
{
    private bool _recording;

    public event EventHandler RecordingFailedEvent;
    
    public void UpdateRecordState(out bool recordingToSave)
    {
        _recording = !_recording;
        if (!_recording)
        {
            recordingToSave = poolTagRecorder.GetSnapshotCount() != 0;
        }
        else
        {
            recordingToSave = false;
        }
    }

    public string GetRecordingStateAsString()
    {
        return _recording ? "Recording" : "Not recording";
    }

    public void SnapShot()
    {
        if (!_recording) return;
        var result = poolTagRecorder.TakeAndStoreSnapshot();
        if (!result)
        {
            _recording = false;
            OnRecordingFailed();
        }
    }

    public void NotifyRecordingFinished()
    {
        poolTagRecorder.CleanUp();
    }
    
    private void OnRecordingFailed()
    {
        RecordingFailedEvent?.Invoke(this, EventArgs.Empty);
    }
    
}