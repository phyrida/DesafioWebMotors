using System;

namespace DesafioWebMotors.Domain.ExtendsMethods
{
    public static class ObjectExtends
    {
        public static int ToInt32(this object value)
        {
            int outValue = 0;
            if (int.TryParse(value.ToString(), out outValue))
                return outValue;
            else
                throw new Exception();
        }

        public static long ToInt64(this object value)
        {
            long outValue = 0;
            if (long.TryParse(value.ToString(), out outValue))
                return outValue;
            else
                throw new Exception();
        }
    }
}
