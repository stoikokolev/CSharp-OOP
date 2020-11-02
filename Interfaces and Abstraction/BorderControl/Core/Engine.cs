using System.Collections.Generic;
using System.Linq;
using BorderControl.Contacts;
using BorderControl.IO;
using BorderControl.Models;

namespace BorderControl.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private List<ISociety> society;

        public Engine()
        {
            this.society = new List<ISociety>();
        }

        public Engine(IReader reader, IWriter writer)
        : this()
        {
            this.writer = new ConsoleWriter();
            this.reader = new ConsoleReader();
        }

        public void Run()
        {
            AddUnits();

            PrintOutput();
        }

        private void PrintOutput()
        {
            var year = reader.Read();
            foreach (var unit in this.society
                .OfType<IBirthable>()
                .Where(u => u.BirthDate.EndsWith(year)))
            {
                this.writer.WriteLine(unit.BirthDate);
            }
        }

        private void AddUnits()
        {
            string command;
            ISociety unit = null;

            while ((command = this.reader.Read()) != "End")
            {
                var cmdArgs = command.Split();
                var name = cmdArgs[1];
                if (command.StartsWith("Citizen"))
                {
                    unit = this.CreateCitizen(name, cmdArgs);
                }
                else if (command.StartsWith("Robot"))
                {
                    unit = CreateRobot(name, cmdArgs);
                }
                else if (command.StartsWith("Pet"))
                {
                    unit = CreatePet(name, cmdArgs);
                }

                this.society.Add(unit);
            }
        }

        private IPet CreatePet(string name, string[] cmdArgs)
        {
            IPet pet;
            var birthDate = cmdArgs[2];
            pet = new Pet(name, birthDate);
            return pet;
        }

        private IHuman CreateCitizen(string name, string[] cmdArgs)
        {
            IHuman citizen;
            var age = int.Parse(cmdArgs[2]);
            var id = cmdArgs[3];
            var birthdate = cmdArgs[4];
            citizen = new Citizen(name, age, id, birthdate);
            return citizen;
        }

        private IRobot CreateRobot(string model, string[] cmdArgs)
        {
            IRobot robot;
            var id = cmdArgs[2];
            robot = new Robot(model, id);
            return robot;
        }
    }
}
