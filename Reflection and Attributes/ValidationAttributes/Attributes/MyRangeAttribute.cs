using System;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.ValidateRange(minValue,maxValue);
            this.maxValue = maxValue;
            this.minValue = minValue;
        }

        public override bool IsValid(object obj)
        {
            if (obj is int value)
            {
                return value >= this.minValue && value <= this.maxValue;
            }
            else
            {
                throw new InvalidOperationException("Cannot validate give data type!");
            }
        }

        private void ValidateRange(int minValuePar, int maxValuePar)
        {
            if (minValuePar > maxValuePar)
            {
                throw new ArgumentException("Invalid range!");
            }
        }
    }
}
