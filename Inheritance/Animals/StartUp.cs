using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                var engine = new Engine();
                engine.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
