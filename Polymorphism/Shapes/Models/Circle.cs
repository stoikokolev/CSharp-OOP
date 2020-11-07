using System;
using Shapes.Common;
using Shapes.Models.Contracts;

namespace Shapes.Models
{
    public class Circle : Shape, ICircle
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get => this.radius;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(GlobalConstants.NEGATIVE_OR_ZENO_MESSAGE);
                }

                this.radius = value;
            }
        }

        public override double CalculatePerimeter() => 2 * Math.PI * this.Radius;

        public override double CalculateArea() => Math.PI * this.Radius * this.Radius;

        

    }
}
