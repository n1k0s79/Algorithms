using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Euler
{
    [TestClass]
    public class Problem004_Largest_Palindrome
    {
        [TestMethod]
        public void Problem4_Largest_Palindrome()
        {
            Assert.AreEqual(906609, Problem004_Largest_Palindrome.Solution());
            Assert.AreEqual(906609, Problem004_Largest_Palindrome.Solution_Optimization1());
            Assert.AreEqual(906609, Problem004_Largest_Palindrome.Solution_Optimization2());
            Assert.AreEqual(906609, Problem004_Largest_Palindrome.Solution_Optimization3());
        }

        /// <summary>
        /// Brute force 
        /// </summary>
        /// <returns></returns>
        public static int Solution()
        {
            int ret = 0;
            var muls = new List<Mul>();

            // 810 000 iterations (1000-100) ^ 2 -> 900^2
            for (int a = 100; a < 1000; a++)
            {
                for (int b = 100; b < 1000; b++)
                {
                    int p = a * b;
                    muls.Add(new Mul(a, b));

                    if (Math.Palindrome.IsPalindrome(p))
                    {
                        if (p > ret)
                        {
                            ret = p;
                        }
                    }
                }
            }

            return ret;
        }

        /// <summary> Move backwards AND stop the inner loop when the product is less than the currently found max</summary>
        public static int Solution_Optimization1()
        {
            var muls = new List<Mul>();
            int ret = 0;

            for (int a = 999; a >= 100; a--)
            {
                for (int b = 999; b >= 100; b--)
                {
                    muls.Add(new Mul(a, b));
                    int p = a * b;
                    if (p <= ret) break; // products have started going downwards. I do not need to keep on checking them
                    if (Math.Palindrome.IsPalindrome(p))
                    {
                        if (p > ret)
                        {
                            ret = p;
                        }
                    }
                }
            }

            // done 9200 multiplications
            return ret;
        }

        /// <summary> Many numbers are checked twice: e.g. 123 * 555, 555 * 123. Stop doing that!</summary>
        public static int Solution_Optimization2()
        {
            int ret = 0;
            var muls = new List<Mul>();
            for (int a = 999; a >= 100; a--)
            {
                for (int b = a; b >= 100; b--) // I only want the distinct pairs of a and b
                {
                    int p = a * b;
                    muls.Add(new Mul(a, b));
                    if (p <= ret) break;
                    if (Math.Palindrome.IsPalindrome(p))
                    {
                        if (p > ret)
                        {
                            ret = p;
                        }
                    }
                }
            }

            // 7020 multiplications done
            return ret;
        }

        class Mul
        {
            public int a;
            public int b;
            public Mul(int a, int b)
            {
                this.a = a;
                this.b = b;
            }
            public int p { get { return a*b; } }
            public override string ToString()
            {
                return a + "*" + b + "=" + p;
            }
        }

        public static int Solution_Optimization3()
        {
            // The number I am looking for has 6 digits. It cannot have 5 because 143 * 777 = 111111 which is already 6 digits long
            // Its digits should be:
            // abccba
            // 100000a + 10000b + 1000c + 100c + 10b + a
            // 100001a + 10010b + 1100c
            // 11 * (9091a + 910b + 100c)
            // This means that the product MUST be divisible by 11.
            // Which in turn means that either a OR b is divisible by 11
            // If a IS divisible then b ISN'T and vice versa.

            int ret = 0;
            int a = 999;
            var muls = new List<Mul>();
            while (a >=100)
            {
                int b = a;
                int deltaB = 1;
                if (a%11 == 0) // a is divisible by 11 so b is not
                {
                    // search all just like the previous algorithm
                }
                else
                {
                    // b IS divisible by 11
                    b = 990; // the largest product of 11
                    deltaB = 11; // hop - decrement b by 11
                }
                
                while (b>=100)
                {
                    muls.Add(new Mul(a, b));
                    int p = a * b;
                    if (p < ret) break;
                    if (Math.Palindrome.IsPalindrome(p)) ret = p;
                    b-=deltaB;
                }
                a--;
            }

            // 1757 multiplications
            return ret;
        }
    }
}