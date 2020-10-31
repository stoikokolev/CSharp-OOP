using System;

namespace PizzaCalories.Core
{
    public class Engine
    {
        public void Run()
        {
            Pizza pizza;
            Dough dough;

            try
            {
                var pizzaInfo = Console.ReadLine().Split();
                var pizzaName = pizzaInfo[1];
                pizza = new Pizza(pizzaName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            try
            {
                var doughInfo = Console.ReadLine().Split();
                var flour = doughInfo[1];
                var bakingTech = doughInfo[2];
                var weight = double.Parse(doughInfo[3]);
                dough = new Dough(flour.ToLower(), bakingTech.ToLower(), weight);

                pizza.PizzaDough = dough;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            string toppingInfo;

            while ((toppingInfo = Console.ReadLine()) != "END")
            {
                try
                {
                    var toppingParams = toppingInfo.Split();
                    var toppingName = toppingParams[1].ToLower();
                    var toppingWeight = double.Parse(toppingParams[2]);
                    var topping = new Topping(toppingName, toppingWeight);

                    pizza.Add(topping);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            try
            {
                Console.WriteLine($"{pizza.Name} - {pizza.PizzaCalories():f2} Calories.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
