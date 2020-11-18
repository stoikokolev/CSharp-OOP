using System.Collections.Generic;

namespace PrototypePattern
{
    public class PizzaMenu
    {
        private readonly Dictionary<string, PizzaPrototype> pizzas;

        public PizzaMenu()
        {
            this.pizzas=new Dictionary<string, PizzaPrototype>();
        }

        public PizzaPrototype this[string name]
        {
            get => this.pizzas[name];
            set => this.pizzas.Add(name, value);
        }
    }
}
