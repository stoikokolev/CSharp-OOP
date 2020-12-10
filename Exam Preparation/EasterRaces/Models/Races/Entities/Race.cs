using System;
using System.Collections.Generic;
using System.Linq;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Races.Entities
{
    public class Race:IRace
    {
        private string name;
        private const int MinNameLength = 5;
        private const int MinLaps = 1;
        private int laps;
        private List<IDriver> drivers;

        public Race(string name, int laps)
        {
            this.name = name;
            this.laps = laps;
            this.drivers = new List<IDriver>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    var msg = string.Format(ExceptionMessages.InvalidName, value, MinNameLength);
                    throw new ArgumentException(msg);
                }

                this.name = value;
            }
        }

        public int Laps
        {
            get => this.laps;
            private set
            {
                if (value < 1)
                {
                    var msg = string.Format(ExceptionMessages.InvalidNumberOfLaps, MinLaps);
                    throw new ArgumentException(msg);
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => this.drivers.AsReadOnly();

        public void AddDriver(IDriver driver)
        {
            if (driver is null)
            {
                throw new ArgumentException(ExceptionMessages.DriverInvalid);
            }

            if (!driver.CanParticipate)
            {
                var msg = string.Format(ExceptionMessages.DriverNotParticipate, driver.Name);
                throw new ArgumentException(msg);
            }

            if (this.drivers.Contains(driver))
            {
                var msg = string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name);
                throw new ArgumentException(msg);
            }

            this.drivers.Add(driver);
        }
    }
}