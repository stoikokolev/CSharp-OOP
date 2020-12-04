namespace OnlineShop.Models.Products.Components
{
    public class RandomAccessMemory:Component
    {
        public RandomAccessMemory(int id, string manufacturer, string model, decimal price, double overall, int generation) 
            : base(id, manufacturer, model, price, overall, generation)
        {
        }

        public override double OverallPerformance => base.OverallPerformance*1.2;
    }
}