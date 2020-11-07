using System;

namespace Shapes.Models
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        private double Radius
        {
            get => this.radius;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }

                this.radius = value;
            }
        }

        public override double CalculatePerimeter() => 2 * Math.PI * this.Radius;

        public override double CalculateArea() => Math.PI * this.Radius * this.Radius;

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
