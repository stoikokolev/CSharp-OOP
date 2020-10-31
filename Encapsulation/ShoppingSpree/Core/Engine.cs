using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingSpree.Models;

namespace ShoppingSpree.Core
{
    public class Engine
    {
        private List<Product> products;
        private List<Person> people;

        public Engine()
        {
            this.products = new List<Product>();
            this.people = new List<Person>();
        }

        public void Run()
        {
            AddPeople();

            AddProducts();

            BuyLoop();

            PrintOutput();
        }

        private void PrintOutput()
        {
            foreach (var person in this.people)
            {
                Console.WriteLine(person);
            }
        }

        private void BuyLoop()
        {
            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                var cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                var personName = cmdArgs[0];
                var productName = cmdArgs[1];

                try
                {
                    var person = this.people.First(p => p.Name == personName);
                    var product = this.products.First(p => p.Name == productName);

                    person.BuyProduct(product);

                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }
        }

        private void AddProducts()
        {
            var productArgs = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (var line in productArgs)
            {
                var currentProductTokens = line.Split('=', StringSplitOptions.RemoveEmptyEntries).ToArray();

                var name = currentProductTokens[0];
                var cost = decimal.Parse(currentProductTokens[1]);

                var product = new Product(name, cost);

                this.products.Add(product);
            }
        }

        private void AddPeople()
        {
            var peopleArgs = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (var line in peopleArgs)
            {
                var currentPeopleTokes = line.Split('=', StringSplitOptions.RemoveEmptyEntries).ToArray();

                var name = currentPeopleTokes[0];
                var money = decimal.Parse(currentPeopleTokes[1]);

                var person = new Person(name, money);

                this.people.Add(person);
            }
        }
    }
}
