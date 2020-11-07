using System;
using System.Runtime.CompilerServices;
using Shapes.Common;
using Shapes.Models.Contracts;

namespace Shapes.Models
{
    public class Rectangle:Shape, IRectangle
    {
        private double height;
        private double width;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Height
        {
            get => this.height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(GlobalConstants.NEGATIVE_OR_ZENO_MESSAGE);
                }

                this.height = value;
            }
        }

        public double Width
        {
            get => this.width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(GlobalConstants.NEGATIVE_OR_ZENO_MESSAGE);
                }

                this.width = value;
            }
        }

        public override double CalculatePerimeter() => 2 * (this.Width + this.Height);

        public override double CalculateArea() => this.Width * this.Height;

       
    }
}
