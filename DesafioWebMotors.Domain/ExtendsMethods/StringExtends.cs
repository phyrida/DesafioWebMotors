using System;

namespace DesafioWebMotors.Domain.ExtendsMethods
{
    public static class StringExtends
    {
        public static int ToInt32(this string value)
        {
            int outValue = 0;
            if (int.TryParse(value, out outValue))
                return outValue;
            else
                throw new Exception("Value not is a int number");

        }

        public static long ToInt64(this string value)
        {
            long outValue = 0;
            if (long.TryParse(value, out outValue))
                return outValue;
            else
                throw new Exception("Value not is a long number");

        }
    }
}
