namespace OnlineShop.Models.Products.Peripherals
{
    public class Headset:Peripheral
    {
        public Headset(int id, string manufacturer, string model, decimal price, double overall, string connectionType) 
            : base(id, manufacturer, model, price, overall, connectionType)
        {
        }
    }
}