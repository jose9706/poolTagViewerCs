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
    private bool _isPaused;
    private readonly Timer timer;
    private readonly IEnumerable<ToolStripItem> intervalMenuItems;
    private TimerState _prevState;

    public TimerHelper(Timer timer, IEnumerable<ToolStripItem> intervalMenuItems, TimerState initState, TextBox? textBox)
    {
        this.timer = timer;
        this.intervalMenuItems = intervalMenuItems;
        _prevState = initState;

        if (textBox != null)
        {
            textBox.Text = initState.TextToDisplay;
        }

    }
    public void SetTimerState(TimerState timerState, TextBox? textBox)
    {
        timer.Interval = timerState.IntervalMillisecond;
        timer.Stop();
        ClearCheckedItemIntervalMenu();
        timerState.ToolStripItem.Checked = true;

        if(textBox != null)
        {
            textBox.Text = timerState.TextToDisplay;
        }

        _prevState = timerState;
        _isPaused = false;
        timer.Start();
    }

    public void SimplePause() => timer.Stop();

    public void SimpleResume() => timer.Start();

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
        timer.Start();
    }

    private void Pause(ToolStripMenuItem pauseMenuItem, TextBox? textBox)
    {
        timer.Stop();
        _isPaused = true;
        ClearCheckedItemIntervalMenu();
        pauseMenuItem.Checked = true;
        if (textBox != null)
        {
            textBox.Text = _prevState.TextToDisplay;
        }
    }

    private void ClearCheckedItemIntervalMenu()
    {
        foreach (var dropDownItem in intervalMenuItems)
        {
            if (dropDownItem is ToolStripMenuItem item)
            {
                item.Checked = false;
            }
        }
    }
}