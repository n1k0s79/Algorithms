using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeWars
{
    [TestClass]
    public class IsThisATriangle
    {
        /*
        Implement a method that accepts 3 integer values a, b, c. The method should return true if a triangle can be built with the sides of given length and false in any other case.
        (In this case, all triangles must have surface greater than 0 to be accepted).
        */

        // HINT: Triangle inequality
        // In mathematics, the triangle inequality states that for any triangle, the sum of the lengths of any two sides must be greater than or equal to the length of the remaining side.[
        [TestMethod]
        public void Test()
        {
            Assert.IsTrue(IsTriangle(5, 7, 10));
            Assert.IsFalse(IsTriangle(-5, 7, 10));
            Assert.IsFalse(IsTriangle(0, 7, 10));
            Assert.IsFalse(IsTriangle(1, 2, 3));

            Assert.IsFalse(IsTriangle(- 1, 2, 3));
            Assert.IsFalse(IsTriangle(-1, 2, 3));
            Assert.IsFalse(IsTriangle(1, -2, 3));
            Assert.IsFalse(IsTriangle(1, 2, -3));

            Assert.IsFalse(IsTriangle(1, 2, 4));
            Assert.IsFalse(IsTriangle(4, 1, 2));
            Assert.IsFalse(IsTriangle(1, 4, 2));

            Assert.IsFalse(IsTriangle(1, 2, 3));
            Assert.IsFalse(IsTriangle(1, 3, 2));
            Assert.IsFalse(IsTriangle(3, 1, 2));
        }

        public static bool IsTriangle(int a, int b, int c)
        {
            if (a >= b + c) return false;
            if (b >= a + c) return false;
            if (c >= a + b) return false;            
            return true;
        }

        public static bool IsTriangleAlt(int a, int b, int c) => a + b > c && b + c > a && a + c > b;
    }
}
