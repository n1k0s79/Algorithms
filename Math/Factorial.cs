using System;

namespace Math
{
    public class Factorial
    {
        public static long Calculate(int n)
        {
            long ret = 1;
            for(int i=1; i<=n; i++)
            {
                ret *= i;
            }
            return ret;
        }

        public static int GetPrecalculated(int n)
        {
            int[] calculated = new int[] { 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800, 39916800, 479001600 };
            if (n > 12) throw new Exception("Factorial overflow");
            return calculated[n - 1];
        }
    }
}