using System.Numerics;

namespace Math
{
    public static class BigIntegerExtensions
    {
        public static BigInteger Power(int ibase, int exponent)
        {
            var ret = new BigInteger(ibase);
            for (int i = 1; i < exponent; i++) ret *= ibase;
            return ret;
        }
    }
}
