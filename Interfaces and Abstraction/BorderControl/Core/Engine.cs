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

        private List<IIdentifiable> society;

        public Engine()
        {
            this.society = new List<IIdentifiable>();
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
            var code = reader.Read();

            foreach (var identifiable in this.society.Where(i => i.ID.EndsWith(code)))
            {
                writer.WriteLine(identifiable.ID);
            }
        }

        private void AddUnits()
        {
            string command;
            IIdentifiable unit = null;

            while ((command = this.reader.Read()) != "End")
            {
                var cmdArgs = command.Split();
                var name = cmdArgs[0];
                if (cmdArgs.Length == 3)
                {
                    unit = this.CreateCitizen(name, cmdArgs);
                }
                else if (cmdArgs.Length == 2)
                {
                    unit = CreateRobot(name, cmdArgs);
                }

                this.society.Add(unit);
            }
        }

        private Citizen CreateCitizen(string name, string[] cmdArgs)
        {
            Citizen citizen;
            var age = int.Parse(cmdArgs[1]);
            var id = cmdArgs[2];
            citizen = new Citizen(name, age, id);
            return citizen;
        }

        private Robot CreateRobot(string model, string[] cmdArgs)
        {
            Robot robot;
            var id = cmdArgs[1];
            robot = new Robot(model, id);
            return robot;
        }
    }
}
