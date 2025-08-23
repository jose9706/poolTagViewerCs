namespace poolViewer;
using System.Text.RegularExpressions;

internal sealed partial class FilterForm : Form
{
    private List<Regex> Filters { get; } = new(10);
    
    public event NewFilter FilterArrivedEvent;
    public delegate void NewFilter(List<Regex> filters);

    
    public FilterForm()
    {
        InitializeComponent();
    }

    public void ClearFilter()
    {
        this.Filters.Clear();
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
        Filters.Clear();
        foreach (var line in lines)
        {
            if (line.Length > 4)
            {
                MessageBox.Show($"Filters should be of length 4 or less {line}" ,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (!string.IsNullOrEmpty(line))
            {
                // Compiled is slow but the one "paying" for it is this form.
                Filters.Add(new Regex(line, RegexOptions.Singleline | RegexOptions.NonBacktracking | RegexOptions.Compiled));
            }
        }

        return true;
    }
    
    private void RaiseFilterArrivedEvent()
    {
        FilterArrivedEvent.Invoke(this.Filters);
    }
}