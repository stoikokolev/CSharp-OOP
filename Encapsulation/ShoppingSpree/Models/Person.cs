using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingSpree.Common;

namespace ShoppingSpree.Models
{
    public class Person
    {
        private const decimal MONEY_MIN_VALUE = 0m;

        private string name;
        private decimal money;
        private List<Product> bag;

        private Person()
        {
            this.bag = new List<Product>();
        }

        public Person(string name, decimal money)
            : this()
        {
            this.Name = name;
            this.Money = money;
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.InvalidNameExceptionMessage);
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;
            set
            {
                if (value < MONEY_MIN_VALUE)
                {
                    throw new ArgumentException(GlobalConstants.InvalidMoneyExceptionMessage);
                }
                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag => this.bag.AsReadOnly();

        public void BuyProduct(Product product)
        {
            if (this.money < product.Cost)
            {
                throw new InvalidOperationException(string.Format(GlobalConstants.InsufficientMoneyExceptionMessage, this.Name, product.Name));
            }

            this.money -= product.Cost;
            this.bag.Add(product);
        }

        public override string ToString()
        {
            var productsOutput = this.bag.Count > 0 ? string.Join(", ", this.bag) : "Nothing bought";
            return $"{this.name} - {productsOutput}";
        }
    }
}
