using System;
using System.Collections.Generic;
using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Enums;
using RobotService.Utilities.Messages;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private readonly IGarage garage;
        private readonly Dictionary<ProcedureType, IProcedure> procedures;

        public Controller()
        {
            garage = new Garage();
            procedures = new Dictionary<ProcedureType, IProcedure>();
            this.SeedProcedures();
        }

        public string
            Manufacture(string robotType, string name, int energy, int happiness,
                int procedureTime) //TODO Implement with Factory Pattern
        {
            if (!Enum.TryParse(robotType, out RobotType robotTypeEnum))
            {
                var msg = string.Format(ExceptionMessages.InvalidRobotType, robotType);
                throw new ArgumentException(msg);
            }

            IRobot robot = robotTypeEnum switch
            {
                RobotType.PetRobot => new PetRobot(name, energy, happiness, procedureTime),
                RobotType.HouseholdRobot => new HouseholdRobot(name, energy, happiness, procedureTime),
                RobotType.WalkerRobot => new WalkerRobot(name, energy, happiness, procedureTime),
                _ => null
            };

            this.garage.Manufacture(robot);

            return string.Format(OutputMessages.RobotManufactured, name);
        }

        public string Chip(string robotName, int procedureTime) => this.DoService(robotName, procedureTime,
            ProcedureType.Chip, OutputMessages.ChipProcedure);

        public string TechCheck(string robotName, int procedureTime) => this.DoService(robotName, procedureTime,
            ProcedureType.TechCheck, OutputMessages.TechCheckProcedure);

        public string Rest(string robotName, int procedureTime) => this.DoService(robotName, procedureTime,
            ProcedureType.Rest, OutputMessages.RestProcedure);

        public string Work(string robotName, int procedureTime)
        {
            var robot = this.GetRobotByName(robotName);
            var procedure = this.procedures[ProcedureType.Work];
            procedure.DoService(robot, procedureTime);

            return string.Format(OutputMessages.WorkProcedure, robot.Name,procedureTime);
        }

        public string Charge(string robotName, int procedureTime) => this.DoService(robotName, procedureTime,
            ProcedureType.Charge, OutputMessages.ChipProcedure);

        public string Polish(string robotName, int procedureTime) => this.DoService(robotName, procedureTime,
            ProcedureType.Polish, OutputMessages.PolishProcedure);

        public string Sell(string robotName, string ownerName)
        {
            var robot = this.GetRobotByName(robotName);

            this.garage.Sell(robotName, ownerName);

            return string.Format(robot.IsChipped ? OutputMessages.SellChippedRobot : OutputMessages.SellNotChippedRobot, ownerName);
        }

        public string History(string procedureType)
        {
            Enum.TryParse(procedureType, out ProcedureType procedureTypeEnum);

            var procedure = this.procedures[procedureTypeEnum];

            return procedure.History().Trim();
        }

        private void SeedProcedures()
        {
            this.procedures.Add(ProcedureType.Charge, new Charge());
            this.procedures.Add(ProcedureType.Chip, new Chip());
            this.procedures.Add(ProcedureType.Polish, new Polish());
            this.procedures.Add(ProcedureType.Rest, new Rest());
            this.procedures.Add(ProcedureType.TechCheck, new TechCheck());
            this.procedures.Add(ProcedureType.Work, new Work());
        }

        private IRobot GetRobotByName(string robotName)
        {
            if (this.garage.Robots.ContainsKey(robotName)) return this.garage.Robots[robotName];
            var msg = string.Format(ExceptionMessages.InexistingRobot, robotName);
            throw new ArgumentException(msg);
        }

        private string DoService(string robotName, int procedureTime, ProcedureType procedureType,
            string outputTemplate)
        {
            var robot = this.GetRobotByName(robotName);
            var procedure = this.procedures[procedureType];
            procedure.DoService(robot, procedureTime);

            return string.Format(outputTemplate, robot.Name);
        }
    }
}