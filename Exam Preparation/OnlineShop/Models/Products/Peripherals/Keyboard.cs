namespace OnlineShop.Models.Products.Peripherals
{
    public class Keyboard:Peripheral
    {
        public Keyboard(int id, string manufacturer, string model, decimal price, double overall, string connectionType) 
            : base(id, manufacturer, model, price, overall, connectionType)
        {
        }
    }
}