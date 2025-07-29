using System.Reflection;
using poolViewer.Pool;

namespace poolViewer;

internal partial class MainForm : Form
{
    private readonly PoolDataHandler _poolDataHandler;
    private SortOrder nextSorting = SortOrder.None;

    public MainForm(PoolDataHandler handler)
    {
        _poolDataHandler = handler;
        InitializeComponent();
        PerformanceHacksForDataGrid();
        _poolDataHandler.RefreshPoolInfo();
        foreach (var item in _poolDataHandler.PoolTags)
        {
            poolTagInfoBindingSource.List.Add(item);
        }
        timer1.Enabled = true;
        dataGridView1.CellFormatting += dataGridView1_CellFormatting;
    }

    private void PerformanceHacksForDataGrid()
    {
        dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        dataGridView1.RowHeadersVisible = false;
        typeof(DataGridView).InvokeMember("DoubleBuffered",
        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
        null, dataGridView1, [true]);
    }

    private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
        object retVal = propertyName switch
        {
            nameof(tagInfo.Tag) => tagInfo.Tag,
            nameof(tagInfo.Type) => tagInfo.Type,
            nameof(tagInfo.Source) => tagInfo.Source,
            nameof(tagInfo.Frees) => tagInfo.Frees,
            nameof(tagInfo.Allocs) => tagInfo.Allocs,
            nameof(tagInfo.Bytes) => tagInfo.Bytes,
            nameof(tagInfo.B_Alloc) => tagInfo.B_Alloc,
            nameof(tagInfo.Description) => tagInfo.Description,
            nameof(tagInfo.Diff) => tagInfo.Diff,
            nameof(tagInfo.KB) => tagInfo.KB,
            _ => throw new ArgumentException($"What even is this property... ? {propertyName}"),
        };
        return retVal;
    }

    private void UpdateBindingSourceEfficiently(List<PoolTagInfo> newPoolTags)
    {
        var newItems = newPoolTags.ToDictionary(item => new { item.Tag, item.Type });
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

    private void SetRowChangeState(PoolTagInfo existingInfo, PoolTagInfo newInfo)
    {
        if(newInfo.Diff > existingInfo.Diff)
        {
            existingInfo.Change = ChangeType.Increased;
            return;
        }
        if(newInfo.Diff < existingInfo.Diff)
        {
            existingInfo.Change = ChangeType.Decreased;
            return;
        }

        existingInfo.Change = ChangeType.None;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        _poolDataHandler.RefreshPoolInfo();
        UpdateBindingSourceEfficiently(_poolDataHandler.PoolTags);
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
}