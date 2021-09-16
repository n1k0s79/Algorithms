using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    [TestClass]
    public class NotVerySecure
    {
        // In this example you have to validate if a user input string is alphanumeric.The given string is not nil/null/NULL/None, so you don't have to check that.
        // The string has the following conditions to be alphanumeric:
        // At least one character ("" is not valid)
        // Allowed characters are uppercase / lowercase latin letters and digits from 0 to 9
        // No whitespaces / underscore

        [TestMethod]
        public void Test()
        {
            Assert.IsTrue(Alphanumeric("Mazinkaiser"));
            Assert.IsFalse(Alphanumeric("hello world_"));
            Assert.IsTrue(Alphanumeric("PassW0rd"));
            Assert.IsFalse(Alphanumeric("     "));
            Assert.IsFalse(Alphanumeric("."));
            Assert.IsTrue(Alphanumeric("Ασ"));
        }

        public static bool Alphanumeric(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return false;
            return str.All(c => Char.IsLetter(c) || char.IsNumber(c));
        }
    }
}
