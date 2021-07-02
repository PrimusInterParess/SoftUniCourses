using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;

        private readonly bool inclusive;

        public MyRangeAttribute(int minValue, int maxValue, bool inxInclusive = true)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;

            this.inclusive = inxInclusive;
        }

        public override bool IsValid(object obj)
        {
            int number = (int)obj;

            if (this.inclusive)
            {
                return number >= this.minValue && number <= this.maxValue;

            }

            return number > this.minValue && number < this.maxValue;

        }
    }
}
