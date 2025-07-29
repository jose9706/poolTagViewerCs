
namespace poolConsole
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var poolView = new PoolDataHandler();
            PoolReadingLoop(poolView);
        }

        private static void PoolReadingLoop(PoolDataHandler poolView)
        {
            while (true)
            {
                poolView.ReadPoolInfo();
                poolView.PrintPoolTag();
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
    }
}