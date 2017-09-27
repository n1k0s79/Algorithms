using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
   [TestClass]
    public class Problem027_Quadratic_primes
    {
        [TestMethod]
        public void TestIt()
        {            
            Assert.AreEqual(-59231, Solution());
        }

        private static int Solution()
        {
            int max = 0;
            int ca = 0;
            int cb = 0;
            for (int a = -999; a < 1000; a++)
            {
                for (int b = -1000; b <= 1000; b++)
                {
                    var p = NumberOfPrimesProduced(a, b);
                    if (p > max)
                    {
                        max = p;
                        ca = a;
                        cb = b;
                    }
                }
            }

            return ca * cb;
        }

        private static int NumberOfPrimesProduced(int a, int b)
        {
            int n = 0;
            while (true)
            {
                var p = Produce(a, b, n);
                if (p <= 0) return 0;
                if (!Math.Primes.IsPrime((ulong)p)) break;
                n++;
            }
            return n;
        }

        private static int Produce(int a, int b, int n)
        {
            checked
            {
                var ret = n * n + a * n + b;
                return ret;
            }
        }
    }
}
