namespace poolViewer.FormHelpers;

public static class FormExtensions
{
    public static void ShowErrorMessageWindow(this Form form, string? message)
    {
        MessageBox.Show(form, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    
    public static void ShowInfoMessageWindow(this Form form, string? message)
    {
        MessageBox.Show(form, message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}