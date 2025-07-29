using poolViewer.Pool;

namespace poolViewer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            var poolHandler = new PoolDataHandler();

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(poolHandler));
            
        }
    }
}