
namespace poolViewer;

internal class ListViewHandler
{
    public void ListView_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        // Let the system handle the drawing unless we want full custom control
        e.DrawDefault = true;
    }

    public void ListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
    {
    }

    public void ListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
    {
        e.DrawDefault = true; // Use default header drawing
    }

    private Color GetRowBackColor(int index)
    {

        return Color.White;
    }

    // Method to update values and trigger color changes
    public void UpdateValue(int rowIndex, decimal newValue)
    {
    }
}
