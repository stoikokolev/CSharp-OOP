using System;
using Vehicles.Common;
using Vehicles.Models.Contracts;

namespace Vehicles.Models
{
    public abstract class Vehicle : IDrivable, IRefuelable
    {
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FillQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FillQuantity { get; private set; }

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
            if (fuelAmount > 0)
            {
                this.FillQuantity += fuelAmount;
            }
        }

        public override string ToString() => $"{this.GetType().Name}: {this.FillQuantity:f2}";
    }
}
