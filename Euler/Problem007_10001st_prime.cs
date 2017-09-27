using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Euler
{
    // By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
    // What is the 10001st prime number?

    [TestClass]
    public class Problem007_10001st_prime
    {
        /// <summary> Brute forc, very slow  </summary>
        public static ulong Solution()
        {
            var list = Math.Primes.GenerateFirst(10001);
            return list[list.Count - 1];
        }

        [TestMethod]
        public void TestSolution()
        {
            Assert.AreEqual((ulong)104743, Solution());
        }
    }
}