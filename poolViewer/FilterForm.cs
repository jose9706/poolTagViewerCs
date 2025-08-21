namespace poolViewer;

internal partial class FilterForm : Form
{
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
        Console.WriteLine(this.richTextBox1.Text);
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
                Filters.Add(line);
            }
        }

        return true;
    }

    public delegate void NewFilter(List<string> filters);
    
    public List<string> Filters { get; set; } = new(10);
    public event NewFilter FilterArrivedEvent;

    protected virtual void RaiseFilterArrivedEvent()
    {
        FilterArrivedEvent?.Invoke(this.Filters);
    }
}