﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Euler
{
    // The sequence of triangle numbers is generated by adding the natural numbers.
    // So the 7th triangle number would be 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28. The first ten terms would be:

    // 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...

    //Let us list the factors of the first seven triangle numbers:

    // 1: 1
    // 3: 1,3
    // 6: 1,2,3,6
    //10: 1,2,5,10
    //15: 1,3,5,15
    //21: 1,3,7,21
    //28: 1,2,4,7,14,28

    //We can see that 28 is the first triangle number to have over five divisors.
    //What is the value of the first triangle number to have over five hundred divisors?

    [TestClass]
    public class Problem012_Highly_divisible_triangular_number
    {    

        [TestMethod]
        public void TestSolution()
        {
            Assert.AreEqual(76576500, Solution());
        }

        public static int Solution()
        {
            int i = 1;
            while (true)
            {
                var t = new Math.TriangleNumber(i++);
                var numberOfDivisors = Math.Divisors.CountDivisors((int)t.value);
                if (numberOfDivisors > 500) return (int)t.value;
            }
        }
    }
}