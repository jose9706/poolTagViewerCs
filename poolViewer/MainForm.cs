using System.ComponentModel;
using poolViewer.Pool;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace poolViewer;

internal partial class MainForm : Form
{
    private readonly PoolDataHandler _poolDataHandler;
    private readonly List<PoolTagInfo> _poolTagInfoList = [];
    private SortOrder nextSorting = SortOrder.None;

    public MainForm(PoolDataHandler handler)
    {
        _poolDataHandler = handler;
        InitializeComponent();
        AddMockData();
    }

    private unsafe void AddMockData()
    {
        _poolTagInfoList.Clear();
        _poolDataHandler.ReadPoolInfo();
        foreach (var tag in _poolDataHandler.PoolTags.Values)
        {
            // [TODO] i think this is missing unpaged when PagedUsed > 0... Do we need to add 2 items for this .. ? 
            _poolTagInfoList.Add(new PoolTagInfo
            {
                // TODO no need to convert to string.
                Tag = System.Text.Encoding.ASCII.GetString(tag.Tag.Tag, 4),
                Type = tag.PagedUsed > 0 ? "Paged" : "Non-Paged",
                Allocs = (int)(tag.PagedAllocs + tag.NonPagedAllocs),
                Frees = (int)(tag.PagedFrees + tag.NonPagedFrees),
                Bytes = (long)(tag.PagedUsed + tag.NonPagedUsed),
                Source = "Unknown", // Placeholder for source
                Description = "Unknown" // Placeholder for description
            });
        }

        poolTagInfoBindingSource.DataSource = _poolTagInfoList;
    }

    private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        var column = dataGridView1.Columns[e.ColumnIndex];

        if (dataGridView1.DataSource is BindingSource bindingSource && bindingSource.DataSource is IList<PoolTagInfo> data)
        {

            switch (nextSorting)
            {
                case SortOrder.None:
                    data = [.. data.OrderBy(item => GetPropertyValue(item, column.DataPropertyName))];
                    nextSorting = SortOrder.Ascending;
                    break;
                case SortOrder.Ascending:
                    data = [.. data.OrderByDescending(item => GetPropertyValue(item, column.DataPropertyName))];
                    nextSorting = SortOrder.Descending;
                    break;
                case SortOrder.Descending:
                    data = _poolTagInfoList;
                    nextSorting = SortOrder.None;
                    break;
            }

            poolTagInfoBindingSource.DataSource = new BindingList<PoolTagInfo>(data);
            column.HeaderCell.SortGlyphDirection = nextSorting;
        }
    }

    private object GetPropertyValue(object obj, string propertyName)
    {
        // TODO get rid of reflection slop.
        return obj.GetType().GetProperty(propertyName)?.GetValue(obj, null);
    }

    private unsafe void timer1_Tick(object sender, EventArgs e)
    {
        _poolTagInfoList.Clear();
        _poolDataHandler.ReadPoolInfo();
        var newData = _poolDataHandler.PoolTags;
        if (poolTagInfoBindingSource.DataSource is IList<PoolTagInfo> data)
        {
            foreach (var item in data)
            {
                if(newData.ContainsKey(item.Tag))
                {
                    // update
                    
                } else
                {
                    //new 
                }
            }
        }
        foreach (var tag in _poolDataHandler.PoolTags.Values)
        {
            _poolTagInfoList.Add(new PoolTagInfo
            {
                // TODO no need to convert to string/
                Tag = System.Text.Encoding.ASCII.GetString(tag.Tag.Tag, 4),
                Type = tag.PagedUsed > 0 ? "Paged" : "Non-Paged",
                Allocs = (int)(tag.PagedAllocs + tag.NonPagedAllocs),
                Frees = (int)(tag.PagedFrees + tag.NonPagedFrees),
                Bytes = (long)(tag.PagedUsed + tag.NonPagedUsed),
                Source = "Unknown", // Placeholder for source
                Description = "Unknown" // Placeholder for description
            });
        }

        poolTagInfoBindingSource.DataSource = _poolTagInfoList;
    }

    private void UpdateData(IList<PoolTagInfo> currData, IEnumerable<SystemPoolTag> newData)
    {

    }
}

public struct PoolTagInfo
{
    public string Tag { get; set; }
    public string Type { get; set; }
    public int Allocs { get; set; }
    public int Frees { get; set; }
    public int Diff => Allocs - Frees;
    public long Bytes { get; set; }
    public long KB => Bytes / 1024;
    public long B_Alloc => (Allocs - Frees) > 0 ? Bytes / (Allocs - Frees) : 0;
    public string Source { get; set; }
    public string Description { get; set; }
}