using System.Reflection;
using System.Text.RegularExpressions;
using poolViewer.Pool;

namespace poolViewer;

internal partial class MainForm
{
    private readonly PoolDataHandler _poolDataHandler;
    private readonly List<ToolStripItem> _intervalRelatedMenuItems = [];
    private readonly TimerState TimerState1Seconds;
    private readonly TimerState TimerState2Seconds;
    private readonly TimerState TimerState5Seconds;
    private readonly TimerState TimerState10Seconds;
    private readonly TimerHelper TimerHelper;
    private readonly FilterForm FilterForm = new();

    private readonly Dictionary<string, SortOrder> ColumnSortStates = new()
    {
        [nameof(tagDataGridViewTextBoxColumn)]         = SortOrder.None,
        [nameof(typeDataGridViewTextBoxColumn)]        = SortOrder.None,
        [nameof(allocsDataGridViewTextBoxColumn)]      = SortOrder.None,
        [nameof(freesDataGridViewTextBoxColumn)]       = SortOrder.None,
        [nameof(diffDataGridViewTextBoxColumn)]        = SortOrder.None,
        [nameof(bytesDataGridViewTextBoxColumn)]       = SortOrder.None,
        [nameof(kBDataGridViewTextBoxColumn)]          = SortOrder.None,
        [nameof(bAllocDataGridViewTextBoxColumn)]      = SortOrder.None,
        [nameof(sourceDataGridViewTextBoxColumn)]      = SortOrder.None,
        [nameof(descriptionDataGridViewTextBoxColumn)] = SortOrder.None
    };
    private readonly Dictionary<string, Comparison<PoolTagInfo>> Comparer = new()
    {
        [nameof(tagDataGridViewTextBoxColumn)]         = (a, b) => string.CompareOrdinal(a.Tag, b.Tag),
        [nameof(typeDataGridViewTextBoxColumn)]        = (a, b) => a.Type.CompareTo(b.Type),
        [nameof(allocsDataGridViewTextBoxColumn)]      = (a, b) => a.Allocs.CompareTo(b.Allocs),
        [nameof(freesDataGridViewTextBoxColumn)]       = (a, b) => a.Frees.CompareTo(b.Frees),
        [nameof(diffDataGridViewTextBoxColumn)]        = (a, b) => a.Diff.CompareTo(b.Diff),
        [nameof(bytesDataGridViewTextBoxColumn)]       = (a, b) => a.Bytes.CompareTo(b.Bytes),
        [nameof(kBDataGridViewTextBoxColumn)]          = (a, b) => a.KB.CompareTo(b.KB),
        [nameof(bAllocDataGridViewTextBoxColumn)]      = (a, b) => a.B_Alloc.CompareTo(b.B_Alloc),
        [nameof(sourceDataGridViewTextBoxColumn)]      = (a, b) => string.CompareOrdinal(a.Source, b.Source),
        [nameof(descriptionDataGridViewTextBoxColumn)] = (a, b) => string.CompareOrdinal(a.Description, b.Description)
    };

    // New backing list for virtual mode (current displayed snapshot)
    private readonly List<PoolTagInfo> _display = [];
    // Previous diffs for change detection between refreshes
    private Dictionary<(string Tag, PoolType Type), uint> _previousDiffs = new();

    public MainForm(PoolDataHandler handler)
    {
        _poolDataHandler = handler;
        InitializeComponent();
        PerformanceHacksForDataGrid();
        EnableVirtualMode();
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

    private void EnableVirtualMode()
    {
        dataGridView1.VirtualMode = true;
        dataGridView1.CellValueNeeded += DataGridView1_CellValueNeeded;
        // We will handle sorting manually
        dataGridView1.ColumnHeaderMouseClick += DataGridView1_ColumnHeaderMouseClick;
    }

    private void FilterFormOnFilterArrivedEvent(List<Regex> filters)
    {
        _poolDataHandler.Filter = filters;
        // Rebuild data with new filter
        UpdateGrid();
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
        UpdateGrid();
    }

    private void PerformanceHacksForDataGrid()
    {
        dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        dataGridView1.RowHeadersVisible = false;
        typeof(DataGridView).InvokeMember("DoubleBuffered",
        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
        null, dataGridView1, [true]);
    }

    private void DataGridView1_ColumnHeaderMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
    {
        var column = dataGridView1.Columns[e.ColumnIndex];
        if (!ColumnSortStates.TryGetValue(column.Name, out var nextSorting))
        {
            throw new InvalidOperationException($"Column {column.Name} not found");
        }
        // Toggle sort order
        ColumnSortStates[column.Name] = nextSorting switch
        {
            SortOrder.None => SortOrder.Ascending,
            SortOrder.Ascending => SortOrder.Descending,
            SortOrder.Descending => SortOrder.None,
            _ => ColumnSortStates[column.Name]
        };

        ApplySort(column.Name, ColumnSortStates[column.Name]);
        CleanOtherColumnsSortGlyph(column);
        column.HeaderCell.SortGlyphDirection = ColumnSortStates[column.Name];
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

    private void ApplySort(string columnName, SortOrder order)
    {
        if (order == SortOrder.None)
        {
            // Rebuild list in natural order (current underlying order from handler)
            _display.Clear();
            _display.AddRange(_poolDataHandler.PoolTags);
            return;
        }

        if (!Comparer.TryGetValue(columnName, out var comparison))
        {
            throw new InvalidOperationException($"Column {columnName} not found");
        }
        
        _display.Sort(comparison);
        if (order == SortOrder.Descending)
        {
            _display.Reverse();
        }
    }

    private void UpdateGrid()
    {
        _poolDataHandler.RefreshPoolInfo();
        var newDiffs = new Dictionary<(string Tag, PoolType Type), uint>(_poolDataHandler.PoolTags.Count);

        _display.Clear();
        for (int i = 0; i < _poolDataHandler.PoolTags.Count; i++)
        {
            var item =  _poolDataHandler.PoolTags[i];
            var key = (item.Tag, item.Type);
            if (_previousDiffs.TryGetValue(key, out var prevDiff))
            {
                if (item.Diff > prevDiff) item.Change = ChangeType.Increased;
                else if (item.Diff < prevDiff) item.Change = ChangeType.Decreased;
                else item.Change = ChangeType.None;
            }
            else
            {
                item.Change = ChangeType.None;
            }
            newDiffs[key] = item.Diff;
            _display.Add(item);
        }
        
        _previousDiffs = newDiffs;

        // Reapply current sort if any
        if (ColumnSortStates.Values.Any(val => val != SortOrder.None))
        {
            // Find column with glyph direction set (first one). If event not yet fired, skip.
            var sortedColumn = dataGridView1.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.HeaderCell.SortGlyphDirection != SortOrder.None);
            if (sortedColumn != null)
            {
                ApplySort(sortedColumn.Name, ColumnSortStates[sortedColumn.Name]);
            }
        }

        dataGridView1.RowCount = _display.Count;
        dataGridView1.Invalidate();
    }

    private void Timer1_Tick(object? sender, EventArgs e)
    {
        UpdateGrid();
    }

    private void DataGridView1_CellValueNeeded(object? sender, DataGridViewCellValueEventArgs e)
    {
        if (e.RowIndex < 0 || e.RowIndex >= _display.Count) return;
        var item = _display[e.RowIndex];
        var colName = dataGridView1.Columns[e.ColumnIndex].Name;
        // Map column name to value
        e.Value = colName switch
        {
            nameof(tagDataGridViewTextBoxColumn) => item.Tag,
            nameof(typeDataGridViewTextBoxColumn) => item.Type,
            nameof(allocsDataGridViewTextBoxColumn) => item.Allocs,
            nameof(freesDataGridViewTextBoxColumn) => item.Frees,
            nameof(diffDataGridViewTextBoxColumn) => item.Diff,
            nameof(bytesDataGridViewTextBoxColumn) => item.Bytes,
            nameof(kBDataGridViewTextBoxColumn) => item.KB,
            nameof(bAllocDataGridViewTextBoxColumn) => item.B_Alloc,
            nameof(sourceDataGridViewTextBoxColumn) => item.Source,
            nameof(descriptionDataGridViewTextBoxColumn) => item.Description,
            _ => null
        };
    }

    private void dataGridView1_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || e.RowIndex >= _display.Count) return;
        var info = _display[e.RowIndex];
        if (info.Change == ChangeType.Increased)
            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
        else if (info.Change == ChangeType.Decreased)
            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
        else
            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
    }

    private void SaveToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        saveFileDialog1.ShowDialog(this);
    }

    private void RefreshToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        // If paused just stay paused.
        if (TimerHelper.IsPaused())
        {
            UpdateGrid();    
        }
        else
        {
            TimerHelper.SimplePause();
            UpdateGrid();
            TimerHelper.SimpleResume();    
        }
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
        FilterForm.ClearFilter();
        UpdateGrid();
    }

    private void Filter_Click(object sender, EventArgs e)
    {
        FilterForm.Show(this);
    }
}