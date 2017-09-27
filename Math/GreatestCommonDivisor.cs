using System.Collections.Generic;

namespace Math
{
    public class GreatestCommonDivisor
    {
        /// <summary> Returns the greatest common divisor of two integers </summary>
        /// <remarks> Ευκλείδια μέθοδος, recursive </remarks>
        public static int GetGcd_R(int a, int b)
        {
            int ret;
            if (b == 0)
            {
                ret = a;
            }
            else
            {
                int remainder = a % b;
                ret = GetGcd_R(b, remainder);
            }

            return ret;
        }

        /// <summary> Returns the greatest common divisor of two integers </summary>
        /// <remarks> Extension of Euclidian method by Leonardo Pisano aka Fibonacci (non-recursive) </remarks>
        public static int GetGcd(int a, int b)
        {
            while (b!=0)
            {
                var t = a;
                a = b;
                b = t % b;
            }

            return a;
        }

        /// <summary> Returns the greatest common divisor of two integers </summary>
        /// <remarks> The succint way</remarks>
        public static int Gcd(int a, int b)
        {
            return b == 0 ? a : Gcd(b, a % b);
        }

        public static int Gcd(params int[] numbers)
        {
            int result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                result = Gcd(result, numbers[i]);
            }

            return result;
        }
    }
}