using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Euler
{
    // Special Pythagorean triplet
    // Problem 9

    // A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
    // a^2 + b^2 = c^2

    // For example, 3^2 + 4^2 = 9 + 16 = 25 = 52.

    // There exists exactly one Pythagorean triplet for which a + b + c = 1000.
    // Find the product abc.

    [TestClass]
    public class Problem009_Special_Pythagorean_triplet
    {    
        [TestMethod]
        public void TestSolution()
        {
            Assert.AreEqual(31875000, Solution());
            Assert.AreEqual(31875000, Solution_Unoptimized());
        }

        public static long Solution_Unoptimized()
        {
            int iterations = 0;
            //var checks = new List<string>();
            int a = 3;
            while (true)
            {
                if (a > 1000) break;

                int b = a + 1;
                while (true)
                {
                    if (a + b > 1000) break;

                    int c = b + 1;
                    while (true)
                    {
                        iterations++;
                        //checks.Add(string.Format("{0} {1} {2}", a, b, c));
                        if (a + b + c > 1000) break;

                        bool isTriplet = a * a + b * b == c * c;
                        if (a + b + c == 1000 && isTriplet) return a * b * c;
                        c++;
                    }
                    b++;
                }
                a++;
            }
            return 0;
        }

        public static long Solution()
        {
            var triplets = Math.PythagoreanTriplets.Generate(1000);
            foreach(var t in triplets)
            {
                if (t.Item1 + t.Item2 + t.Item3 == 1000) return t.Item1 * t.Item2 * t.Item3;
            }

            return 0;
        }
    }
}