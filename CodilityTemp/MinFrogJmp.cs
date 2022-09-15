using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codility
{
    [TestClass]
    public class MinimumFrogJump
    {   
        // Time complexity O(1), space complexity O(1)
        public static int solution(int X, int Y, int D)
        {
            double d = (Y - X) / (double)D;
            return (int)Math.Ceiling(d);
        }

        [TestMethod]
        public void TestSolution()
        {
            var ret = solution(10, 85, 30);
            Assert.AreEqual(3, ret);
        }
    }
}