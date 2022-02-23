using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFIS.Misc
{
    public static class DecimalPrecisionExt
    {
        private static bool IsValidSqlDecimal(this decimal value, int precision, int scale)
        {
            var minOverflowValue = (decimal)Math.Pow(10, precision - scale) - (decimal)Math.Pow(10, -scale) / 2;
            return Math.Abs(value) < minOverflowValue;
        }
    }
}
