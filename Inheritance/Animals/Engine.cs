using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class Engine
    {
        private const string END_OF_INPUT_COMMAND = "Beast!";
        private readonly List<Animal> animals;

        public Engine()
        {
            this.animals = new List<Animal>();
        }

        public void Run()
        {
            string type;
            while ((type = Console.ReadLine()) != END_OF_INPUT_COMMAND)
            {
                var animalArgs = Console.ReadLine().Split().ToArray();
                
                this.animals.Add(GetAnimal(type,animalArgs));
                
            }

            PrintAnimals();
        }

        private void PrintAnimals()
        {
            foreach (var animal in this.animals)
            {
                Console.WriteLine(animal);
            }
        }

        private Animal GetAnimal(string type, string[] animalArgs)
        {
            var gender = GetGender(animalArgs);
            var name = animalArgs[0];
            var age = int.Parse(animalArgs[1]);

            Animal animal = null;

            if (type == "Dog")
            {
                animal = new Dog(name, age, gender);
            }
            else if (type == "Cat")
            {
                animal = new Cat(name, age, gender);
            }
            else if (type == "Frog")
            {
                animal = new Frog(name, age, gender);
            }
            else if (type == "Kitten")
            {
                animal = new Kitten(name, age);
            }
            else if (type == "Tomcat")
            {
                animal = new Tomcat(name, age);
            }
            else
            {
                throw new ArgumentException("Invalid input!");
            }

            return animal;

        }

        private string GetGender(string[] animalArgs)
        {
            string gender = null;
            if (animalArgs.Length >= 3)
            {
                gender = animalArgs[2];
            }

            return gender;
        }
    }
}
