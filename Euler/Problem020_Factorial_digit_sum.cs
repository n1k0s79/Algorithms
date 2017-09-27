using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Euler
{
    //n! means n × (n − 1) × ... × 3 × 2 × 1
    //For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
    //and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.
    //Find the sum of the digits in the number 100!

    [TestClass]
    public class Problem020_Factorial_digit_sum
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(648, solution());
        }

        public long solution()
        {
            var b = new Math.BigInt(1);
            for(int i = 1; i<=100; i++)
            {
                b = b * i;
            }
            return b.GetSumOfAllDigits();
        }
    }
}