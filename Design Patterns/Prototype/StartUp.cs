using System;

namespace PrototypePattern
{
    public class StartUp
    {
        static void Main()
        {
            var pizzaMenu = new PizzaMenu
            {
                ["Margarita"] = new Pizza("white", "tomato", "no meat", "mozzarella"),
                ["Peperoni"] = new Pizza("white", "tomato", "peperoni", "mozzarella"),
                ["Cheeses"] = new Pizza("white", "cream", "no meat", "four kinds of cheese")
            };


            var margarita1 = pizzaMenu["Margarita"].Clone() as Pizza;
            Console.WriteLine(margarita1?.GetIngredients());
            
            var peperoni1 = pizzaMenu["Peperoni"].Clone() as Pizza;
            Console.WriteLine(peperoni1?.GetIngredients());

            var peperoni2 = pizzaMenu["Peperoni"].Clone() as Pizza;
            Console.WriteLine(peperoni2?.GetIngredients());

            var cheeses1 = pizzaMenu["Cheeses"].Clone() as Pizza;
            Console.WriteLine(cheeses1?.GetIngredients());
        }
    }
}
