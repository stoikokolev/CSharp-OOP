namespace OnlineShop.Models.Products.Components
{
    public class Motherboard:Component
    {
        public Motherboard(int id, string manufacturer, string model, decimal price, double overall, int generation) 
            : base(id, manufacturer, model, price, overall, generation)
        {
        }

        public override double OverallPerformance => base.OverallPerformance*1.25;
    }
}