using System.Text.RegularExpressions;
using poolViewer.FormHelpers;

namespace poolViewer.Forms;

internal sealed partial class FilterForm : Form
{
    private readonly List<Regex> _filters  = new(10);
    private readonly HashSet<string> _currFilters = [];
    
    public event NewFilter? FilterArrivedEvent;
    public delegate void NewFilter(List<Regex> filters);

    
    public FilterForm()
    {
        InitializeComponent();
    }

    public void ClearFilter()
    {
        this._filters.Clear();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (ValidateFilter(this.richTextBox1.Text))
        {
            RaiseFilterArrivedEvent();
            this.Hide();
        }
        else
        {
            this.richTextBox1.Clear();
        }
    }
    
    private bool ValidateFilter(string text)
    {
        var lines = text.Split('\n');
        _filters.Clear();
        _currFilters.Clear();
        foreach (var line in lines)
        {
            if (line.Length > 4)
            {
                this.ShowErrorMessageWindow($"Filters should be of length 4 or less {line}");
                return false;
            }

            if (!string.IsNullOrEmpty(line))
            {
                if (_currFilters.Add(line))
                {
                    var regex = CreateRegex(line);
                    if (regex != null) _filters.Add(regex);
                }
            }
        }

        return true;
    }
    
    private void RaiseFilterArrivedEvent()
    {
        FilterArrivedEvent?.Invoke(this._filters);
    }
    
    private Regex? CreateRegex(string regex)
    {
        try
        {
            return new Regex(regex,
                RegexOptions.Singleline | RegexOptions.Compiled);
        }
        catch (Exception ex)
        {
            this.ShowErrorMessageWindow($"Failed creating Regex {regex}, error: {ex.Message}");
            return null;
        }  
    }
}