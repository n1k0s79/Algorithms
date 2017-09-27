using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Euler
{
    // Smallest multiple
    // Problem 5
    // 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
    // What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?

    [TestClass]
    public class Problem005_Smallest_Multiple
    {
        /// <summary> Brute forc, very slow  </summary>
        public static long Solution()
        {
            long limit = Math.Factorial.Calculate(20);
            for (long t = 20; t <= limit; t++)
            {
                if (IsDivisibleByAll(t)) return t;
            }
            return 0;
        }

        // brute force!
        private static bool IsDivisibleByAll(long t)
        {
            for (int i = 2; i <= 20; i++)
            {
                if (t % i != 0) return false;
            }
            return true;
        }

        public static ulong Solution_Optimized()
        {
            // calculate LCM by factorization
            return Math.LeastCommonMultiple.CalculateF(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20);
        }
        
        [TestMethod]
        public void TestSolution()
        {
            Assert.AreEqual((ulong)232792560, Solution_Optimized());
            //Assert.AreEqual(232792560, Solution());
        }
    }
}