

using System;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }
        public override bool IsValid(object obj)
        {
            int valueToCheck = 0;
            if (obj is Int32)
            {
                valueToCheck = (int)obj;
            }
            else
            {
                throw new ArgumentException("Value must be an integer!");
            }
            if (valueToCheck< minValue || valueToCheck > maxValue)
            {
                return false;
            }
            return true;
        }
    }
}
