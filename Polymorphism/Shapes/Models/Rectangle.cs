using System;
using System.Runtime.CompilerServices;

namespace Shapes.Models
{
    public class Rectangle:Shape
    {
        private double height;
        private double width;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        private double Height
        {
            get => this.height;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }

                this.height = value;
            }
        }

        private double Width
        {
            get => this.width;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }

                this.width = value;
            }
        }

        public override double CalculatePerimeter() => 2 * (this.Width + this.Height);

        public override double CalculateArea() => this.Width * this.Height;

        public override string Draw()
        {
            return base.Draw()+this.GetType().Name;
        }
    }
}
