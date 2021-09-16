using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeWars
{
    [TestClass]
    public class SquareEveryDigit
    {
        /*
        Description:
        Welcome.In this kata, you are asked to square every digit of a number and concatenate them.
        For example, if we run 9119 through the function, 811181 will come out, because 92 is 81 and 12 is 1.
        Note: The function accepts an integer and returns an integer
        */

        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(81181, SquareDigits(919));
        }

        public static int SquareDigits(int n)
        {
            var result = n
                .ToString()
                .ToCharArray()
                .Select(Char.GetNumericValue)
                .Select(a => (a * a).ToString())
                .Aggregate(string.Empty, (acc, s) => acc + s);
            return int.Parse(result);
        }
    }
}
