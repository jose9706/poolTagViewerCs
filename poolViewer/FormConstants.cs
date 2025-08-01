namespace poolViewer;

internal partial class MainForm : Form
{
    private static class Constants
    {
        public const string RefreshText1Second = "Refreshing every 1 second";
        public const string RefreshText2Seconds = "Refreshing every 2 seconds";
        public const string RefreshText5Seconds = "Refreshing every 5 seconds";
        public const string RefreshText10Seconds = "Refreshing every 10 seconds";
        public const string PausedText = "Paused refresh";
        public const int Seconds1 = 1000;
        public const int Seconds2 = 2000;
        public const int Seconds5 = 5000;
        public const int Seconds10 = 10000;
        public const string DefaultSaveFileExt = "txt";
    }
}