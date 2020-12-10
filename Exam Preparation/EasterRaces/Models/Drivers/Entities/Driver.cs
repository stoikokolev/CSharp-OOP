using System;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver:IDriver
    {
        private string name;
        private ICar car;
        private int numberOfWins;
        private bool canParticipate;
        private const int MinNameLength = 5;

        public Driver(string name)
        {
            this.Name = name;
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

        public ICar Car
        {
            get => this.car;
            private set => this.car = value;
        }

        public int NumberOfWins {
            get => this.numberOfWins;
            private set => this.numberOfWins = value;
        }

        public bool CanParticipate => !(this.car is null);

        public void WinRace()
        {
            this.numberOfWins++;
        }

        public void AddCar(ICar car)
        {
            if (car is null)
            {
                throw new ArgumentException(ExceptionMessages.CarInvalid);
            }

            this.car = car;
        }
    }
}