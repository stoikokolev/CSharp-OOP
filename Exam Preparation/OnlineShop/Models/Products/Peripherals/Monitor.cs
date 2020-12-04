namespace OnlineShop.Models.Products.Peripherals
{
    public class Monitor:Peripheral
    {
        public Monitor(int id, string manufacturer, string model, decimal price, double overall, string connectionType) 
            : base(id, manufacturer, model, price, overall, connectionType)
        {
        }
    }
}