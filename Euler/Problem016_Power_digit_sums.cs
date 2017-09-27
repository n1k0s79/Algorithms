using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using System.Text;

namespace Euler
{  
    [TestClass]
    public class Problem016_Power_digit_sums
    {
        // Power digit sum
        // Problem 16

        // 2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

        // What is the sum of the digits of the number 21000?

        [TestMethod]
        public void TestSolution()
        {
            checked
            {
                var b = new Math.BigInt("2");
                for(int i = 1; i < 1000; i++) b = b * 2;
                long sum = 0;
                foreach(var c in b.Value) sum += long.Parse(c.ToString());

                Assert.AreEqual(1366, sum);
            }            
        }
    }
}