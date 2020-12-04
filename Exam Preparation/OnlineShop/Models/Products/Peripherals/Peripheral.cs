namespace OnlineShop.Models.Products.Peripherals
{
    public abstract class Peripheral : Product, IPeripheral
    {
        protected Peripheral(int id, string manufacturer, string model, decimal price, double overall, string connectionType)
            : base(id, manufacturer, model, price, overall)
        {
            this.ConnectionType = connectionType;
        }

        public string ConnectionType { get; }

        public override string ToString()
        {
            return base.ToString() + $" Connection Type: {this.ConnectionType}";
        }
    }
}