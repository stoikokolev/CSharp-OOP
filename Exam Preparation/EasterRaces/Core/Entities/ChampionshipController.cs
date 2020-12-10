using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private ICollection<IDriver> drivers;
        private ICollection<ICar> cars;
        private ICollection<IRace> races;
        private const int MinDrivers = 3;

        public ChampionshipController()
        {
            this.drivers = new List<IDriver>();
            this.cars = new List<ICar>();
            this.races = new List<IRace>();
        }

        public string CreateDriver(string driverName)
        {
            if (this.drivers.Any(x => x.Name == driverName))
            {
                var msg = string.Format(ExceptionMessages.DriversExists, driverName);
                throw new ArgumentException(msg);
            }
            var driver = new Driver(driverName);

            this.drivers.Add(driver);
            var msgSuccess = string.Format(OutputMessages.DriverCreated, driverName);
            return msgSuccess;
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (this.cars.Any(x => x.Model == model))
            {
                var msg = $"Car {model} is already created.";
                throw new ArgumentException(msg);
            }

            ICar car = type switch
            {
                "Muscle" => new MuscleCar(model, horsePower),
                "Sports" => new SportsCar(model, horsePower),
                _ => null
            };

            this.cars.Add(car);

            var msgSuccess = string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
            return msgSuccess;
        }

        public string CreateRace(string name, int laps)
        {
            if (this.races.Any(x => x.Name == name))
            {
                var msg = string.Format(ExceptionMessages.RaceExists, name);
                throw new InvalidOperationException(msg);
            }

            var race = new Race(name,laps);
            this.races.Add(race);

            var msgSuccess = string.Format(OutputMessages.RaceCreated, name);
            return msgSuccess;
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var race = this.races.FirstOrDefault(x => x.Name == raceName);
            if (race is null)
            {
                var msg = string.Format(ExceptionMessages.RaceNotFound, raceName);
                throw new InvalidOperationException(msg);
            }

            var driver = this.drivers.FirstOrDefault(x => x.Name == driverName);
            if (driver is null)
            {
                var msg = string.Format(ExceptionMessages.DriverNotFound, driverName);
                throw new InvalidOperationException(msg);
            }

            race.AddDriver(driver);

            var msgSuccess = string.Format(OutputMessages.DriverAdded, driverName, raceName);
            return msgSuccess;
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            var driver = this.drivers.FirstOrDefault(x => x.Name == driverName);
            if (driver is null)
            {
                var msg = string.Format(ExceptionMessages.DriverNotFound, driverName);
                throw new InvalidOperationException(msg);
            }

            var car = this.cars.FirstOrDefault(x => x.Model == carModel);
            if (car is null)
            {
                var msg = string.Format(ExceptionMessages.CarNotFound, carModel);
                throw new InvalidOperationException(msg);
            }

            if (driver.CanParticipate)
            {
                driver.AddCar(car);
                return string.Format(OutputMessages.CarReplaced, driverName, carModel);
            }
            driver.AddCar(car);

            var msgSuccess = string.Format(OutputMessages.CarAdded, driverName, carModel);
            return msgSuccess;
        }

        public string StartRace(string raceName)
        {
            var race = this.races.FirstOrDefault(x => x.Name == raceName);
            if (race is null)
            {
                var msg = string.Format(ExceptionMessages.RaceNotFound, raceName);
                throw new InvalidOperationException(msg);
            }
            
            if (race.Drivers.Count < MinDrivers)
            {
                var msgDriverCount = string.Format(ExceptionMessages.RaceInvalid, raceName, MinDrivers);
                throw new InvalidOperationException(msgDriverCount);
            }

            var winners = race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)).Take(3).ToArray();
            this.races.Remove(race);
            var sb = new StringBuilder();
            sb.AppendLine(string.Format(OutputMessages.DriverFirstPosition, winners[0].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverSecondPosition, winners[1].Name, raceName));
            sb.AppendLine(string.Format(OutputMessages.DriverThirdPosition, winners[2].Name, raceName));

            return sb.ToString().TrimEnd();
        }
    }
}