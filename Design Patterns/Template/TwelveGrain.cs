using System;

namespace TemplatePattern
{
    public class TwelveGrain:Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for 12-grain Bread!");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking the 12-grain Bread. (25 minutes)");
        }
    }
}
