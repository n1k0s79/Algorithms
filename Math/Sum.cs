using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math
{
    public class Sum
    {
        /// <summary>
        /// Returns the sum of all integers up to n
        /// 1 + 2 + 3 + ... + n
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static long UpTo_Inneficient(long n)
        {
            long ret = 0;
            for (long i = 1; i <= n; i++) ret += i;
            return ret;
        }

        // Gauss's solution:
        // 1 2 3 4 5 6 7 8 9 10:
        // ------------------------
        // 1  2  3  4  5
        // 10 9  8  7  6
        // 11 11 11 11 11
        // that's 5 times 11
        
        // Question: But what do I do if I have an odd number of integers e.g. 1 2 3 4 5 6 7 8 9?
        // Answer: Add the sequence with itself and then divide by 2:
        // 1  2  3  4  5  6  7  8  9
        // 9  8  7  6  5  4  3  2  1
        // 10 10 10 10 10 10 10 10 10
        // that's 9 * 10
        // 90 / 2 = 45
        public static long UpTo(long n)
        {
            return n*(n + 1)/2;
        }


        public static long OfSquares(long n)
        {
            return (2*n + 1) * (n + 1) * n / 6;
        }
    }
}