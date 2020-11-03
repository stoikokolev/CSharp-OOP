using System;
using Vehicles.Common;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double FUEL_CONSUMPTION_INCREMENT = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }


        public override double FuelConsumption
        {
            get => base.FuelConsumption;
            protected set => base.FuelConsumption = value + FUEL_CONSUMPTION_INCREMENT;
        }

        public string DriveEmpty(double kilometers)
        {
            double fuelNeeded = kilometers * (this.FuelConsumption - FUEL_CONSUMPTION_INCREMENT);
            if (this.FillQuantity < fuelNeeded)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NotEnoughFuelExceptionMessage, this.GetType().Name));
            }

            this.FillQuantity -= fuelNeeded;

            return $"{this.GetType().Name} travelled {kilometers} km";
        }
    }
}
