

using System;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = this.ValidateRange(minValue, maxValue)[0];
            this.maxValue = this.ValidateRange(minValue, maxValue)[1];
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

        /// Validates the range if the places of min and max are replaced!
        
        private int[] ValidateRange(int minValue, int maxValue)
        {
            int[] range = new int[2] { minValue, maxValue};
            if (minValue > maxValue)
            {
                int temp = minValue;
                minValue = maxValue;
                maxValue = temp;
            }
            range[0] = minValue;
            range[1] = maxValue;
            return range;
        }
    }
}
