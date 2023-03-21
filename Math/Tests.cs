using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Math
{
    [TestClass]
    public class Tests
    {
        [TestMethod ]
        public void Perms()
        {
            var k = new int[] { 1, 2, 3 };
            var all = Permutation<int>.GetAllPossible(k);
            var j = Permutation.GetAll(new int[] { 1, 2, 3 }).ToList();
        }

        [TestMethod]
        public void TestGreateCommonDivisor()
        {
            var i = GreatestCommonDivisor.GetGcd_R(12, 11);

            Assert.AreEqual(2, GreatestCommonDivisor.GetGcd_R(6, 2));
            Assert.AreEqual(3, GreatestCommonDivisor.GetGcd_R(12, 9));
            Assert.AreEqual(3, GreatestCommonDivisor.Gcd(12, 9, 6));
        }

        [TestMethod]
        public void TestLeastCommonMultiple()
        {
            // calculate by factorization
            Assert.AreEqual((ulong)232792560, LeastCommonMultiple.CalculateF(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20));

            // calculate by brute force
            // Assert.AreEqual(232792560, LeastCommonMultiple.Calculate(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20));
        }

        [TestMethod]
        public void TestPrimes()
        {
            var k = Primes.LargestPrimeFactor(15);
            var factors = Primes.Factorize(532532);
        }

        [TestMethod]
        public void Palindromes()
        {
            Assert.AreEqual(547391, Palindrome.GetPalindrome(193745));
        }

        [TestMethod]
        public void PrimalityTests()
        {
            var s1 = System.Diagnostics.Stopwatch.StartNew();
            s1.Start();

            for (ulong i = 3; i < 10000000; i+=2)
            {
                //bool a = Primes.IsPrime_Unoptimized(i);
                bool a = Primes.IsPrime(i);
            }

            var l = s1.ElapsedMilliseconds;
        }

        [TestMethod]
        public void TestFibonacci()
        {
            var f = Fibonacci.GetFirst();
            var t = Math.Fibonacci.GenerateFirst(91).ToList();
            foreach(var k in t)
            {
                var a = k;
            }
        }

        [TestMethod]
        public void TestPythagorean()
        {
            var t = Math.PythagoreanTriplets.Generate(100).ToList();
        }

        [TestMethod]
        public void TestWords()
        {
            var w1 = new WordedNumber(555666888123456789);
            var s = "five hundred and fifty five quatrillion six hundred and sixty six trillion eight hundred and eighty eight billion one hundred and twenty three million four hundred and fifty six thousand seven hundred and eighty nine";
            Assert.AreEqual(s, w1.ToString());
        }
    }
}