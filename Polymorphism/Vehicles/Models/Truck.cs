using System;
using Vehicles.Common;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double FUEL_CONSUMPTION_INCREMENT = 1.6;
        private const double REFUEL_EFFICIENCY_PERCENTAGE = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public override double FuelConsumption
        {
            get => base.FuelConsumption;
            protected set => base.FuelConsumption = value + FUEL_CONSUMPTION_INCREMENT;
        }

        public override void Refuel(double fuelAmount)
        {
            var newAmount = fuelAmount * 0.95;
            if (newAmount <= 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NegativeFuelExceptionMessage);
            }
            else if (newAmount + this.FillQuantity > this.TankCapacity)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NotEoughSpaceInTankExceptionMessage, fuelAmount));
            }
            else
            {
                this.FillQuantity += newAmount;
            }
        }

        
    }
}
