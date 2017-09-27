using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Euler
{
    // Non-abundant sums
    // Problem 23
    // A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. 
    // For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.
    // A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.
    // As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24. 
    // By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers. 
    // However, this upper limit cannot be reduced any further by analysis even though it is known that the greatest number 
    // that cannot be expressed as the sum of two abundant numbers is less than this limit.
    // Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.

   [TestClass]
    public class Problem023_Non_abundant_sums
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(4179871, solution());
        }

        public long solution()
        {
            var a = GetAbundants();
            long sum = 0;
            for(int i = 1; i < 28123; i++)
            {
                if (CanBeWritten(i, a)) sum += i;
            }

            return sum;
        }

        private Dictionary<int, int> GetAbundants()
        {
            var ret = new Dictionary<int, int>();
            for (int i = 1; i < 28123; i++)
            {
                var s = Math.Divisors.GetSumOfDivisors(i, false);
                if (s > i) ret.Add(i, 0);
            }

            return ret;
        }

        private bool CanBeWritten(int a, Dictionary<int,int> abundants)
        {
            foreach(var kvp in abundants)
            {
                int d = a - kvp.Key;
                if (abundants.ContainsKey(d)) return true;
            }

            return false;
        }
    }
}