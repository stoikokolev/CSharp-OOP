using System;

namespace TemplatePattern
{
    public class WhiteWheat : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for WhiteWheat Bread!");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking the WhiteWheat Bread. (15 minutes)");
        }
    }
}
