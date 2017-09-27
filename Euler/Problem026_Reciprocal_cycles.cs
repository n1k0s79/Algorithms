using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    //    A unit fraction contains 1 in the numerator.The decimal representation of the unit fractions with denominators 2 to 10 are given:
    //    1/2	= 	0.5
    //    1/3	= 	0.(3)
    //    1/4	= 	0.25
    //    1/5	= 	0.2
    //    1/6	= 	0.1(6)
    //    1/7	= 	0.(142857)
    //    1/8	= 	0.125
    //    1/9	= 	0.(1)
    //    1/10	= 	0.1 
    //Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle.It can be seen that 1/7 has a 6-digit recurring cycle.
    //Find the value of d< 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.

   [TestClass]
    public class Problem026_Reciprocal_cycles
    {
        [TestMethod]
        public void TestIt()
        {
            Assert.AreEqual(983, GetMaxRepetendLength());
        }

        private static int GetMaxRepetendLength()
        {
            var max = 0;
            var d = 0;
            for (int i = 11; i < 1000; i++)
            {
                var length = GetRepetendLegth(i);
                if (length > max)
                {
                    max = length;
                    d = i;
                }
            }

            return d;
        }

        // Asking for the repetend length of a fraction with denominator d amounts to asking for 
        // the smallest power of 10 whose remainder, when divided by d, is 1.
        private static int GetRepetendLegth(int d)
        {
            var sum = 0;
            var k = new Math.Primes.Factorized((ulong)d);
            foreach (var p in k.Factors)
            {
                var l = GetRepetendLegthI(p.Number);
                sum += l;
            }
            return sum;
        }

        private static int GetRepetendLegthI(int prime)
        {
            int exp = 1;
            while (true)
            {                
                var number = Pow10(exp);
                if (prime < number)
                {
                    var divisor = prime;
                    var quotient = number / divisor;
                    var remainder = number - quotient * divisor;

                    var r = number - quotient * prime;
                    if (r == 0) return 0;
                    if (r == 1) return exp;
                }
                exp++;
            }
        }

        private static System.Numerics.BigInteger Pow10(int exponent)
        {
            var ret = new System.Numerics.BigInteger(10);
            for(int i = 1; i <exponent; i++) ret *= 10;
            return ret;
        }
    }
}
