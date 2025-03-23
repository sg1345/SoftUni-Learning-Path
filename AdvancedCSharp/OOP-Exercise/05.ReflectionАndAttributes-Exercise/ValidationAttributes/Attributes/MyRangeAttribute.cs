using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public int minValue { get; }
        public int maxValue { get; }
        public override bool IsValid(object obj)
        {
            if (obj is int && (int)obj >= minValue && (int)obj <= maxValue)
            {
                return true;
            }
            return false;
        }
    }
}
