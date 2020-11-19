namespace PrototypePattern
{
    public class Pizza : PizzaPrototype
    {
        private readonly string dough;
        private readonly string sauce;
        private readonly string meat;
        private readonly string cheese;

        public Pizza(string dough, string sauce, string meat, string cheese)
        {
            this.dough = dough;
            this.sauce = sauce;
            this.meat = meat;
            this.cheese = cheese;
        }

        //returns cloned object
        public override PizzaPrototype Clone() => this.MemberwiseClone() as PizzaPrototype;

        public string GetIngredients() => $"Pizza of {this.dough} dough with {this.sauce} sauce, {this.meat} and {this.cheese}.";
    }
}
