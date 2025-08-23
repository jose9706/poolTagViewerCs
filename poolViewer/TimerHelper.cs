using Timer = System.Windows.Forms.Timer;

namespace poolViewer;

public struct TimerState(int intervalMillisecond, string textToDisplay, ToolStripMenuItem toolStripItem)
{
    public int IntervalMillisecond { get; } = intervalMillisecond;

    public string TextToDisplay { get; } = textToDisplay;

    public ToolStripMenuItem ToolStripItem { get; } = toolStripItem;
}

public class TimerHelper
{
    private const string PausedText = "Paused";
    private readonly Timer _timer;
    private readonly IEnumerable<ToolStripItem> _intervalMenuItems;
    private bool _isPaused;
    private TimerState _prevState;

    public TimerHelper(Timer timer, IEnumerable<ToolStripItem> intervalMenuItems, TimerState initState, TextBox? textBox)
    {
        this._timer = timer;
        this._intervalMenuItems = intervalMenuItems;
        _prevState = initState;

        if (textBox != null)
        {
            textBox.Text = initState.TextToDisplay;
        }
    }

    public bool IsPaused()
    {
        return _isPaused;
    }
    
    public void SetTimerState(TimerState timerState, TextBox? textBox)
    {
        _timer.Interval = timerState.IntervalMillisecond;
        _timer.Stop();
        ClearCheckedItemIntervalMenu();
        timerState.ToolStripItem.Checked = true;

        if(textBox != null)
        {
            textBox.Text = timerState.TextToDisplay;
        }

        _prevState = timerState;
        _isPaused = false;
        _timer.Start();
    }

    public void SimplePause() => _timer.Stop();

    public void SimpleResume() => _timer.Start();

    public void PauseOrResume(ToolStripMenuItem pauseMenuItem, TextBox? textBox)
    {
        if (_isPaused)
        {
            Resume(pauseMenuItem, textBox);
        } else
        {
            Pause(pauseMenuItem, textBox);
        }
    }

    private void Resume(ToolStripMenuItem pauseMenuItem, TextBox? textBox)
    {
        ClearCheckedItemIntervalMenu();
        _prevState.ToolStripItem.Checked = true;
        pauseMenuItem.Checked = false;
        if (textBox != null)
        {
            textBox.Text = _prevState.TextToDisplay;
        }

        _isPaused = false;
        _timer.Start();
    }

    private void Pause(ToolStripMenuItem pauseMenuItem, TextBox? textBox)
    {
        _timer.Stop();
        _isPaused = true;
        ClearCheckedItemIntervalMenu();
        pauseMenuItem.Checked = true;
        if (textBox != null)
        {
            textBox.Text = PausedText;
        }
    }

    private void ClearCheckedItemIntervalMenu()
    {
        foreach (var dropDownItem in _intervalMenuItems)
        {
            if (dropDownItem is ToolStripMenuItem item)
            {
                item.Checked = false;
            }
        }
    }
}