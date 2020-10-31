using System;
using ShoppingSpree.Core;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main()
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
