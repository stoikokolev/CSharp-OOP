using System;
using ShoppingSpree.Common;

namespace ShoppingSpree.Models
{
    public class Product
    {
        private string name;
        private decimal cost;
        private const decimal COST_MIN_VALUE = 0m;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.InvalidNameExceptionMessage);
                }

                this.name = value;
            }
        }

        public decimal Cost
        {
            get => this.cost;
            private set
            {
                if (value < COST_MIN_VALUE)
                {
                    throw new ArgumentException(GlobalConstants.InvalidMoneyExceptionMessage);
                }

                this.cost = value;
            }
        }

        public override string ToString() => this.name;
    }
}
