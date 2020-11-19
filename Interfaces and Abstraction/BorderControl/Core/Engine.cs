using System.Collections.Generic;
using System.Linq;
using BorderControl.Contacts;
using BorderControl.Models;

namespace BorderControl.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly List<IBuyer> society;

        public Engine()
        {
            this.society = new List<IBuyer>();
        }

        public Engine(IReader reader, IWriter writer)
        : this()
        {
            this.writer = writer;
            this.reader = reader;
        }

        public void Run()
        {
            AddBuyers();

            BuyingFood();

            PrintOutput();
        }

        private void PrintOutput()
        {
            var food = this.society.Sum(person => person.Food);
            writer.WriteLine(food);
        }


        private void BuyingFood()
        {
            string command;

            while ((command = reader.Read()) != "End")
            {
                foreach (var person in this.society.Where(b => b.Name == command))
                {
                    person.BuyFood();
                }
            }
        }

        private void AddBuyers()
        {
            var repeats = int.Parse(reader.Read());
            for (int i = 0; i < repeats; i++)
            {
                var args = reader.Read().Split();
                IBuyer human = null;
                var name = args[0];
                var age = int.Parse(args[1]);
                if (args.Length == 4)
                {
                    human = AddHuman(args, name, age);
                }
                else if (args.Length == 3)
                {
                    human = AddRabel(args, name, age);
                }

                this.society.Add(human);
            }
        }

        private static IBuyer AddRabel(string[] args, string name, int age)
        {
            var group = args[2];
            IBuyer rabel = new Rabel(name, age, @group);
            return rabel;
        }

        private static IBuyer AddHuman(string[] args, string name, int age)
        {
            var id = args[2];
            var birthdate = args[3];
            IBuyer human = new Citizen(name, age, id, birthdate);
            return human;
        }

        //private IPet CreatePet(string name, string[] cmdArgs)
        //{
        //    IPet pet;
        //    var birthDate = cmdArgs[2];
        //    pet = new Pet(name, birthDate);
        //    return pet;
        //}

        //private IHuman CreateCitizen(string name, string[] cmdArgs)
        //{
        //    IHuman citizen;
        //    var age = int.Parse(cmdArgs[2]);
        //    var id = cmdArgs[3];
        //    var birthdate = cmdArgs[4];
        //    citizen = new Citizen(name, age, id, birthdate);
        //    return citizen;
        //}

        //private IRobot CreateRobot(string model, string[] cmdArgs)
        //{
        //    IRobot robot;
        //    var id = cmdArgs[2];
        //    robot = new Robot(model, id);
        //    return robot;
        //}
    }
}
