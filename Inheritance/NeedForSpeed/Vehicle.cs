namespace NeedForSpeed
{
    public abstract class Vehicle
    {
        private const double DEFAULT_FUEL_CONSUMPTION = 1.25;
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public virtual double DefaultFuelConsumption => DEFAULT_FUEL_CONSUMPTION;

        public virtual double FuelConsumption { get; set; }

        public double Fuel { get; private set; }

        public int HorsePower { get; }

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= kilometers * this.DefaultFuelConsumption;
        }
    }
}
