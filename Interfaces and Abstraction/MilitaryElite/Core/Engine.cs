using System;
using System.Collections.Generic;
using System.Linq;
using MilitaryElite.Contracts;
using MilitaryElite.Core.Contracts;
using MilitaryElite.Exceptions;
using MilitaryElite.IO.Contracts;
using MilitaryElite.Models;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly ICollection<ISoldier> soldiers;

        private Engine()
        {
            this.soldiers = new List<ISoldier>();
        }

        public Engine(IReader reader, IWriter writer)
        : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command;

            while ((command = this.reader.ReadLine()) != "End")
            {
                var cmdArg = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                var soldierType = cmdArg[0];
                var id = int.Parse(cmdArg[1]);
                var firstName = cmdArg[2];
                var lastName = cmdArg[3];
                ISoldier soldier = null;

                if (soldierType == "Private")
                {
                    soldier = AddPrivate(cmdArg, id, firstName, lastName);

                }
                else if (soldierType == "LieutenantGeneral")
                {
                    soldier = AddGeneral(cmdArg, id, firstName, lastName);
                }
                else if (soldierType == "Engineer")
                {
                    var salary = decimal.Parse(cmdArg[4]);
                    string corps = cmdArg[5];

                    try
                    {
                        IEngineer engineer = CreateEngineer(cmdArg, id, firstName, lastName, salary, corps);

                        soldier = engineer;
                    }
                    catch (InvalidCorpsException)
                    {
                        continue;
                    }
                }
                else if (soldierType == "Commando")
                {
                    var salary = decimal.Parse(cmdArg[4]);
                    string corps = cmdArg[5];

                    try
                    {
                        var commando = GetCommando(id, firstName, lastName, salary, corps, cmdArg);

                        soldier = commando;
                    }
                    catch (InvalidCorpsException )
                    {
                        continue;
                    }
                }
                else if (soldierType == "Spy")
                {
                    var codeNumber = int.Parse(cmdArg[4]);

                    soldier = new Spy(id, firstName, lastName, codeNumber);
                }

                if (soldier != null)
                {
                    this.soldiers.Add(soldier);
                }
            }

            foreach (var soldier in this.soldiers)
            {
                this.writer.WriteLine(soldier);
            }
        }

        private static ICommando GetCommando(int id, string firstName, string lastName, decimal salary, string corps,
            string[] cmdArg)
        {
            ICommando commando = new Commando(id, firstName, lastName, salary, corps);
            var missionArgs = cmdArg.Skip(6).ToArray();

            for (int i = 0; i < missionArgs.Length; i += 2)
            {
                try
                {
                    var missionCodeName = missionArgs[i];
                    var MissionState = missionArgs[i + 1];

                    IMission mission = new Mission(missionCodeName, MissionState);
                    commando.AddMission(mission);
                }
                catch (InvalidMissionCompletionException )
                {
                    continue;
                }
            }

            return commando;
        }

        private static IEngineer CreateEngineer(string[] cmdArg, int id, string firstName, string lastName, decimal salary, string corps)
        {
            IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

            var repairArgs = cmdArg.Skip(6).ToArray();

            for (int i = 0; i < repairArgs.Length; i += 2)
            {
                var partName = repairArgs[i];
                var hoursWorked = int.Parse(repairArgs[i + 1]);

                IRepair repair = new Repair(partName, hoursWorked);
                engineer.AddRepair(repair);
            }

            return engineer;
        }

        private ILieutenantGeneral AddGeneral(string[] cmdArg, int id, string firstName, string lastName)
        {
            ISoldier soldier;
            var salary = decimal.Parse(cmdArg[4]);
            ILieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);

            foreach (var pid in cmdArg.Skip(5))
            {
                ISoldier privateToAdd = this.soldiers.First(s => s.Id == int.Parse(pid));
                general.AddPrivate(privateToAdd);
            }

            soldier = general;

            return general;
        }

        private static IPrivate AddPrivate(string[] cmdArg, int id, string firstName, string lastName)
        {
            ISoldier soldier;
            var salary = decimal.Parse(cmdArg[4]);
            soldier = new Private(id, firstName, lastName, salary);
            return (IPrivate)soldier;
        }
    }
}
