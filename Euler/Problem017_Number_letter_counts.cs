using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using System.Text;

namespace Euler
{  
    [TestClass]
    public class Problem017_Number_letter_counts
    {
        // Number letter counts
        // Problem 17
        //If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
        //If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?
        //NOTE: Do not count spaces or hyphens.For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters.The use of "and" when writing out numbers is in compliance with British usage.

      [TestMethod]
        public void TestSolution()
        {
            var w342 = new Math.WordedNumber(342);
            var l342 = w342.ToString().Replace(" ", "").Length;
            Assert.AreEqual(23, l342);

            var w115 = new Math.WordedNumber(115);
            var l115 = w115.ToString().Replace(" ", "").Length;
            Assert.AreEqual(20, l115);

            long sum = 0;
            for(int i=1; i<=1000; i++)
            {
                var w = new Math.WordedNumber(i);
                long l = w.ToString().Replace(" ", "").Length;
                checked
                {
                    sum += l;
                }                
            }
            Assert.AreEqual(21124, sum);
        }
    }
}