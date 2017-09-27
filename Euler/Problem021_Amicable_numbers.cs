using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Euler
{
    //Amicable numbers
    //Problem 21

    //Let d(n) be defined as the sum of proper divisors of n(numbers less than n which divide evenly into n).
    //If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.

    // For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. 
    // The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.

    //Evaluate the sum of all the amicable numbers under 10000.

    [TestClass]
    public class Problem021_Amicable_numbers
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(31626, solution());
        }

        public long solution()
        {
            var dict = new Dictionary<int, int>();
            for (int i = 1; i < 10000; i++) dict.Add(i, Math.Divisors.GetSumOfDivisors(i, false));

            var amicable = new List<int>();

            foreach(var kvp in dict)
            {
                if (kvp.Key != kvp.Value && dict.ContainsKey(kvp.Value) && dict[kvp.Value] == kvp.Key)
                {
                    if (!amicable.Contains (kvp.Key)) amicable.Add(kvp.Key);
                    if (!amicable.Contains(kvp.Value)) amicable.Add(kvp.Value);
                }
            }

            int sum = 0;
            foreach (var am in amicable) sum += am;

            return sum;
        }
    }
}