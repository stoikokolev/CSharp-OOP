namespace Vehicles.Models
{
    public class Truck:Vehicle
    {
        private const double FUEL_CONSUMPTION_INCREMENT = 1.6;
        private const double REFUEL_EFFICIENCY_PERCENTAGE = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {

        }

        public override double FuelConsumption
        {
            get => base.FuelConsumption;
            protected set => base.FuelConsumption = value + FUEL_CONSUMPTION_INCREMENT;
        }

        public override void Refuel(double fuelAmount)
        {
            base.Refuel(fuelAmount*REFUEL_EFFICIENCY_PERCENTAGE);
        }
    }
}
