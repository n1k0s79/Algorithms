﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeWars
{
    [TestClass]
    public class BinaryAddition
    {
        /*
        Implement a function that adds two numbers together and returns their sum in binary. The conversion can be done before, or after the addition.
        The binary number returned should be a string.
        Examples:
        add_binary(1, 1) == "10" (1 + 1 = 2 in decimal or 10 in binary)
        add_binary(5, 9) == "1110" (5 + 9 = 14 in decimal or 1110 in binary)         
        */

        [TestMethod]
        public void Test()
        {
            Assert.AreEqual("10", add_binary(1, 1));
            Assert.AreEqual("1110", add_binary(5, 9));
        }

        public static string add_binary(int a, int b) => Convert.ToString(a + b, 2);
    }
}
