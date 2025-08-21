using System.Reflection;
using poolViewer.Pool;

namespace poolViewer;

internal partial class MainForm : Form
{
    private readonly PoolDataHandler _poolDataHandler;
    private SortOrder nextSorting = SortOrder.None;
    private readonly List<ToolStripItem> _intervalRelatedMenuItems = [];
    private readonly TimerState TimerState1Seconds;
    private readonly TimerState TimerState2Seconds;
    private readonly TimerState TimerState5Seconds;
    private readonly TimerState TimerState10Seconds;
    private readonly TimerHelper TimerHelper;
    private readonly FilterForm FilterForm = new FilterForm();

    public MainForm(PoolDataHandler handler)
    {
        _poolDataHandler = handler;
        InitializeComponent();
        PerformanceHacksForDataGrid();
        DataFirstRefresh();
        TimerConfigSetup();
        dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        SaveDialogConfigSetup();
        _intervalRelatedMenuItems.AddRange(IntervalMenuItem.DropDownItems.Cast<ToolStripItem>());
        _intervalRelatedMenuItems.Add(pauseToolStripMenuItem);
        TimerState1Seconds = new TimerState(Constants.Seconds1, Constants.RefreshText1Second, second1MenuItem);
        TimerState2Seconds = new TimerState(Constants.Seconds2, Constants.RefreshText2Seconds, seconds2MenuItem);
        TimerState5Seconds = new TimerState(Constants.Seconds5, Constants.RefreshText5Seconds, seconds5MenuItem);
        TimerState10Seconds = new TimerState(Constants.Seconds10, Constants.RefreshText10Seconds, seconds10MenuItem);
        TimerHelper = new TimerHelper(timer1, _intervalRelatedMenuItems, TimerState2Seconds, currIntervalBox);
        FilterForm.FilterArrivedEvent += FilterFormOnFilterArrivedEvent;
        FilterForm.FormClosing += FilterForm_FormClosing;
    }

    private void FilterFormOnFilterArrivedEvent(List<string> filters)
    {
        _poolDataHandler.Filter = filters;
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
        saveFileDialog1.OverwritePrompt = true;
        saveFileDialog1.DefaultExt = Constants.DefaultSaveFileExt;
        saveFileDialog1.CheckWriteAccess = true;
        saveFileDialog1.AddExtension = true;
        saveFileDialog1.FileOk += SaveFileDialog1_FileOk;
    }

    private void SaveFileDialog1_FileOk(object? sender, System.ComponentModel.CancelEventArgs e)
    {
        using var f = new StreamWriter(saveFileDialog1.FileName);
        foreach (var item in _poolDataHandler.PoolTags)
        {
            f.WriteLine($"Tag: {item.Tag}, Type: {item.Type}, Allocs: {item.Allocs}, Frees: {item.Frees}, Bytes: {item.Bytes}, Source: {item.Source}, Description: {item.Description}");
        }
    }

    private void DataFirstRefresh()
    {
        _poolDataHandler.RefreshPoolInfo();
        foreach (var item in _poolDataHandler.PoolTags)
        {
            poolTagInfoBindingSource.List.Add(item);
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

    private void DataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        var column = dataGridView1.Columns[e.ColumnIndex];

        var data = poolTagInfoBindingSource.List.Cast<PoolTagInfo>().ToList();

        switch (nextSorting)
        {
            case SortOrder.None:
                data = [.. data.OrderBy(item => GetPropertyVal(item, column.DataPropertyName))];
                nextSorting = SortOrder.Ascending;
                break;
            case SortOrder.Ascending:
                data = [.. data.OrderByDescending(item => GetPropertyVal(item, column.DataPropertyName))];
                nextSorting = SortOrder.Descending;
                break;
            case SortOrder.Descending:
                data = [.. _poolDataHandler.PoolTags];
                nextSorting = SortOrder.None;
                break;
        }

        for (var i = 0; i < data.Count; i++)
        {
            poolTagInfoBindingSource.List[i] = data[i];
        }

        column.HeaderCell.SortGlyphDirection = nextSorting;
        dataGridView1.Refresh();
    }

    private static object GetPropertyVal(PoolTagInfo tagInfo, string propertyName)
    {
        // TODO a lot of boxing...
        var property = typeof(PoolTagInfo).GetProperty(propertyName);
        if (property == null)
            throw new ArgumentException($"Property '{propertyName}' not found on PoolTagInfo");

        var retVal = property.GetValue(tagInfo)!;
        return retVal;
    }

    private void UpdateGrid()
    {
        _poolDataHandler.RefreshPoolInfo();
        var newItems = _poolDataHandler.PoolTags.ToDictionary(item => new { item.Tag, item.Type });
        var existingItems = poolTagInfoBindingSource.List.Cast<PoolTagInfo>().ToDictionary(item => new { item.Tag, item.Type });

        foreach (var key in newItems.Keys)
        {
            if (existingItems.TryGetValue(key, out var existingItem))
            {
                var newItem = newItems[key];
                SetRowChangeState(existingItem, newItem);
                existingItem.Allocs = newItem.Allocs;
                existingItem.Frees = newItem.Frees;
                existingItem.Bytes = newItem.Bytes;
            }
            else
            {
                poolTagInfoBindingSource.Add(newItems[key]);
            }
        }

        foreach (var key in existingItems.Keys.Except(newItems.Keys).ToList())
        {
            var itemToRemove = existingItems[key];
            poolTagInfoBindingSource.Remove(itemToRemove);
        }

        dataGridView1.Refresh();
    }

    private static void SetRowChangeState(PoolTagInfo existingInfo, PoolTagInfo newInfo)
    {
        if (newInfo.Diff > existingInfo.Diff)
        {
            existingInfo.Change = ChangeType.Increased;
            return;
        }
        if (newInfo.Diff < existingInfo.Diff)
        {
            existingInfo.Change = ChangeType.Decreased;
            return;
        }

        existingInfo.Change = ChangeType.None;
    }

    private void Timer1_Tick(object? sender, EventArgs e)
    {
        UpdateGrid();
    }


    private void dataGridView1_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dataGridView1.Rows[e.RowIndex].DataBoundItem is PoolTagInfo info)
        {
            if (info.Change == ChangeType.Increased)
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
            else if (info.Change == ChangeType.Decreased)
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
            else
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
        }
    }

    private void SaveToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        saveFileDialog1.ShowDialog(this);
    }

    private void RefreshToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        TimerHelper.SimplePause();
        UpdateGrid();
        TimerHelper.SimpleResume();
    }

    private void second1MenuItem_Click(object? sender, EventArgs e)
    {
        TimerHelper.SetTimerState(TimerState1Seconds, currIntervalBox);
    }

    private void seconds2MenuItem_Click(object? sender, EventArgs e)
    {
        TimerHelper.SetTimerState(TimerState2Seconds, currIntervalBox);
    }

    private void seconds5MenuItem_Click(object? sender, EventArgs e)
    {
        TimerHelper.SetTimerState(TimerState5Seconds, currIntervalBox);
    }

    private void seconds10MenuItem_Click(object? sender, EventArgs e)
    {
        TimerHelper.SetTimerState(TimerState10Seconds, currIntervalBox);
    }

    private void pauseToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        TimerHelper.PauseOrResume(pauseToolStripMenuItem, currIntervalBox);
    }

    private void FilterForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        // Just hide the window because its simple and we might need again :)
        if (e.CloseReason == CloseReason.UserClosing)
        {
            e.Cancel = true;
            FilterForm.Hide();
        }
    }

    private void FilterClear_Click(object sender, EventArgs e)
    {
        _poolDataHandler.ClearFilter();
    }

    private void Filter_Click(object sender, EventArgs e)
    {
        FilterForm.Show(this);
    }
}