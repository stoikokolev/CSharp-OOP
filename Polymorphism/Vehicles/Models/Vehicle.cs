using System;
using Vehicles.Common;
using Vehicles.Models.Contracts;

namespace Vehicles.Models
{
    public abstract class Vehicle : IDrivable, IRefuelable
    {
        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FillQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double TankCapacity { get; }

        public double FillQuantity
        {
            get => this.fuelQuantity;
            protected set
            {
                if (this.TankCapacity >= value)
                {
                    this.fuelQuantity = value;
                }
                else
                {
                    this.fuelQuantity = 0;
                }

            }
        }

        public virtual double FuelConsumption { get; protected set; }

        public string Drive(double kilometers)
        {
            double fuelNeeded = kilometers * this.FuelConsumption;
            if (this.FillQuantity < fuelNeeded)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NotEnoughFuelExceptionMessage, this.GetType().Name));
            }

            this.FillQuantity -= fuelNeeded;

            return $"{this.GetType().Name} travelled {kilometers} km";
        }

        public virtual void Refuel(double fuelAmount)
        {
            if (fuelAmount <= 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NegativeFuelExceptionMessage);
            }
            else if (fuelAmount + this.FillQuantity > this.TankCapacity)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NotEoughSpaceInTankExceptionMessage, fuelAmount));
            }
            else
            {
                this.FillQuantity += fuelAmount;
            }
        }

        public override string ToString() => $"{this.GetType().Name}: {this.FillQuantity:f2}";
    }
}
