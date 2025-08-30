using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using poolViewer.PoolHandling;

namespace poolViewer;

internal partial class MainForm
{
    private readonly PoolDataHandler _poolDataHandler;
    private readonly List<ToolStripItem> _intervalRelatedMenuItems = [];
    private readonly TimerState _timerState1Seconds;
    private readonly TimerState _timerState2Seconds;
    private readonly TimerState _timerState5Seconds;
    private readonly TimerState _timerState10Seconds;
    private readonly TimerHelper _timerHelper;
    private readonly FilterForm _filterForm = new();
    private readonly SnapShoter poolTagRecorder;
    private readonly PoolGridController _poolGridController;
    private bool _recording = false;

    public MainForm(PoolDataHandler handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        _poolDataHandler = handler;
        InitializeComponent();
        PerformanceHacksForDataGrid();
        EnableVirtualMode();
        TimerConfigSetup();
        SaveDialogConfigSetup();
        dataGridView1.CellFormatting += DataGridView1_CellFormatting;
        _filterForm.FilterArrivedEvent += FilterFormOnFilterArrivedEvent;
        _filterForm.FormClosing += FilterForm_FormClosing;
        
        _intervalRelatedMenuItems.AddRange(IntervalMenuItem.DropDownItems.Cast<ToolStripItem>());
        _intervalRelatedMenuItems.Add(pauseToolStripMenuItem);

        _poolGridController = new PoolGridController(_poolDataHandler);
        poolTagRecorder = new SnapShoter(_poolDataHandler.PoolTags);
        
        _timerState1Seconds = new TimerState(Constants.Seconds1, Constants.RefreshText1Second, second1MenuItem);
        _timerState2Seconds = new TimerState(Constants.Seconds2, Constants.RefreshText2Seconds, seconds2MenuItem);
        _timerState5Seconds = new TimerState(Constants.Seconds5, Constants.RefreshText5Seconds, seconds5MenuItem);
        _timerState10Seconds = new TimerState(Constants.Seconds10, Constants.RefreshText10Seconds, seconds10MenuItem);
        _timerHelper = new TimerHelper(timer1, _intervalRelatedMenuItems, _timerState2Seconds, currIntervalBox);
    }
    
#region FormCallbacks
    private async void SaveFileDialog1_FileOk(object? sender, System.ComponentModel.CancelEventArgs e)
    {
        saveAsToolStripMenuItem.Enabled = false;
        try
        {
            await poolTagRecorder.TakeAndSaveSnapShotToFileAsync(saveFileDialog1.FileName);
        }
        catch (OperationCanceledException)
        {
            MessageBox.Show(this, "Save canceled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, $"Error saving snapshots: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            saveAsToolStripMenuItem.Enabled = true;
        }
    }
    private void DataGridView1_ColumnHeaderMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
    {
        var column = dataGridView1.Columns[e.ColumnIndex];
        CleanOtherColumnsSortGlyph(column);
        column.HeaderCell.SortGlyphDirection = _poolGridController.ToggleSort(column.DataPropertyName);
        dataGridView1.Invalidate();
    }

    private void Timer1_Tick(object? sender, EventArgs e)
    {
        SignalUpdateGrid();
    }

    private void DataGridView1_CellValueNeeded(object? sender, DataGridViewCellValueEventArgs e)
    {
        var propertyName = dataGridView1.Columns[e.ColumnIndex].DataPropertyName;
        e.Value = _poolGridController.GetCellValue(e.RowIndex, propertyName);
    }

    private void DataGridView1_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        var rowColor = _poolGridController.GetCellColor(e.RowIndex);
        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = rowColor ?? Color.Gray;
    }

    private void SaveToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        saveFileDialog1.ShowDialog(this);
    }

    private void RefreshToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        // If paused just stay paused.
        if (_timerHelper.IsPaused())
        {
            SignalUpdateGrid();
        }
        else
        {
            _timerHelper.SimplePause();
            SignalUpdateGrid();
            _timerHelper.SimpleResume();
        }
    }

    private void Second1MenuItem_Click(object? sender, EventArgs e)
    {
        _timerHelper.SetTimerState(_timerState1Seconds, currIntervalBox);
    }

    private void Seconds2MenuItem_Click(object? sender, EventArgs e)
    {
        _timerHelper.SetTimerState(_timerState2Seconds, currIntervalBox);
    }

    private void Seconds5MenuItem_Click(object? sender, EventArgs e)
    {
        _timerHelper.SetTimerState(_timerState5Seconds, currIntervalBox);
    }

    private void Seconds10MenuItem_Click(object? sender, EventArgs e)
    {
        _timerHelper.SetTimerState(_timerState10Seconds, currIntervalBox);
    }

    private void PauseToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        _timerHelper.PauseOrResume(pauseToolStripMenuItem, currIntervalBox);
    }

    private void FilterForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        // Just hide the window because its simple and we might need again :)
        if (e.CloseReason == CloseReason.UserClosing)
        {
            e.Cancel = true;
            _filterForm.Hide();
        }
    }

    private void FilterClear_Click(object sender, EventArgs e)
    {
        _poolDataHandler.ClearFilter();
        _filterForm.ClearFilter();
        SignalUpdateGrid();
    }

    private void Filter_Click(object sender, EventArgs e)
    {
        _filterForm.Show(this);
    }

    private void Button1_Click(object sender, EventArgs e)
    {
        _recording = !_recording;
        if (_recording == false)
        {
            // check if we actually recorded stuff and then show something.
        }
    }
#endregion
    

#region FormUtilities
    private void SignalUpdateGrid()
    {
        _poolGridController.UpdateGrid();
        dataGridView1.RowCount = _poolGridController.Display.Count;
        dataGridView1.Invalidate();
    }
    
    private void CleanOtherColumnsSortGlyph(DataGridViewColumn column)
    {
        var columns = dataGridView1.Columns;
        foreach (DataGridViewColumn columnItem in columns)
        {
            if (columnItem.Name != column.Name)
            {
                columnItem.HeaderCell.SortGlyphDirection = SortOrder.None;
            }
        }
    }
    
    private void PerformanceHacksForDataGrid()
    {
        dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        dataGridView1.RowHeadersVisible = false;
        typeof(DataGridView).InvokeMember("DoubleBuffered",
            BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
            null, dataGridView1, [true]);
    }
    
    private void EnableVirtualMode()
    {
        dataGridView1.VirtualMode = true;
        dataGridView1.CellValueNeeded += DataGridView1_CellValueNeeded;
        dataGridView1.ColumnHeaderMouseClick += DataGridView1_ColumnHeaderMouseClick;
    }

    private void FilterFormOnFilterArrivedEvent(List<Regex> filters)
    {
        _poolDataHandler.Filter = filters;
        // Rebuild data with new filter
        SignalUpdateGrid();
    }

    private void TimerConfigSetup()
    {
        timer1.Interval = Constants.Seconds2;
        timer1.Enabled = true;
        timer1.Start();
        timer1.Tick += Timer1_Tick;
        seconds2MenuItem.Checked = true;
    }

    private void SaveDialogConfigSetup()
    {
        saveFileDialog1.Title = "Save Snapshot";
        saveFileDialog1.Filter = "Text Files (.txt)|.txt|All Files (.)|."; // TODO filter working kind of weird.
        saveFileDialog1.FileName = "snapshot.txt";
        saveFileDialog1.OverwritePrompt = true;
        saveFileDialog1.DefaultExt = Constants.DefaultSaveFileExt;
        saveFileDialog1.CheckWriteAccess = true;
        saveFileDialog1.AddExtension = true;
        saveFileDialog1.FileOk += SaveFileDialog1_FileOk;
    }
#endregion
}