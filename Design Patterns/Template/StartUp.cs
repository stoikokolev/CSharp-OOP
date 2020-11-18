using System;

namespace TemplatePattern
{
    public class StartUp
    {
        static void Main()
        {
            var sourDough = new Sourdough();
            sourDough.Make();
            Console.WriteLine();

            var whiteWheat = new WhiteWheat();
            whiteWheat.Make();
            Console.WriteLine();

            var twelveGrain = new TwelveGrain();
            twelveGrain.Make();
            Console.WriteLine();
        }
    }
}
