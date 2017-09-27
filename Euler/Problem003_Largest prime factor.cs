using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Euler
{
    [TestClass]
    public class Problem003_Largest_prime_factor
    {
        public static ulong Solution()
        {
            //return Math.Primes.LargestPrimeFactor_Slow(600851475143); // 6857
            return Math.Primes.LargestPrimeFactor(600851475143);
        }

        [TestMethod]
        public void Problem3_Largest_Prime_Factor()
        {
            var o = Problem003_Largest_prime_factor.Solution();
            Assert.AreEqual((ulong)6857, o);
        }
    }
}