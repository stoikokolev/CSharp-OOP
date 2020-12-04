namespace OnlineShop.Models.Products.Components
{
    public abstract class Component : Product, IComponent
    {
        protected Component(int id, string manufacturer, string model, decimal price, double overall, int generation)
            : base(id, manufacturer, model, price, overall)
        {
            this.Generation = generation;
        }

        public int Generation { get; }

        public override string ToString()
        {
            return base.ToString()+ $" Generation: {this.Generation}";
        }
    }
}