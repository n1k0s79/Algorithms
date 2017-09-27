using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Euler
{
    //The sum of the squares of the first ten natural numbers is,
    //1^2 + 2^2 + ... + 10^2 = 385
    //The square of the sum of the first ten natural numbers is,
    //(1 + 2 + ... + 10)^2 = 552 = 3025
    //Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
    //Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.

    [TestClass]
    public class Problem006_Sum_square_difference
    {
        /// <summary> Brute forc, very slow  </summary>
        public static long Solution()
        {
            return SquareOfSums(100) - Math.Sum.OfSquares(100);
        }

        private static long SumOfSquares_Unoptimized(int n)
        {
            long ret = 0;
            for (int i = 1; i <= n; i++)
            {
                ret += (long)System.Math.Pow(i, 2);
            }
            return ret;
        }

        private static long SquareOfSums(int n)
        {
            long ret = Math.Sum.UpTo(n);
            return (long)System.Math.Pow(ret, 2);
        }

        [TestMethod]
        public void TestSolution()
        {
            Assert.AreEqual(SumOfSquares_Unoptimized(100), Math.Sum.OfSquares(100));
            Assert.AreEqual(25164150, Solution());
        }
    }
}