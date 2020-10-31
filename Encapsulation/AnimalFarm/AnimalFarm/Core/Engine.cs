using System;
using AnimalFarm.Models;

namespace AnimalFarm.Core
{
    public class Engine
    {
        public void Run()
        {
            try
            {
                var name = Console.ReadLine();
                var age = int.Parse(Console.ReadLine());

                var chicken = new Chicken(name, age);
                Console.WriteLine(
                    "Chicken {0} (age {1}) can produce {2} eggs per day.",
                    chicken.Name,
                    chicken.Age,
                    chicken.ProductPerDay);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
