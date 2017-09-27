using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Euler
{
    // Summation of primes
    // Problem 10
    // The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
    // Find the sum of all the primes below two million.

    [TestClass]
    public class Problem010_Summation_of_primes
    {    
        [TestMethod]
        public void TestSolution()
        {
            Assert.AreEqual((ulong)142913828922, Solution());
        }

        public static ulong Solution()
        {
            var primes = Math.Primes.GenerateUpTo((ulong)2000000);
            ulong sum = 0;
            foreach(var p in primes)
            {
                checked { sum += p; }
            }

            return sum;
        }
    }
}