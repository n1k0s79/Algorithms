using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Euler
{
   [TestClass]
    public class Problem029_Distinct_powers
    {
        [TestMethod]
        public void TestIt()
        {
            Assert.AreEqual(9183, DistinctPowers());
        }      

        private static long DistinctPowers()
        {
            var dict = new Dictionary<string, int>();
            for (int a = 2; a <= 100; a++)
            {
                for (int b = 2; b <= 100; b++)
                {                    
                    var p = Math.BigIntegerExtensions.Power(a, b).ToString();
                    if (dict.ContainsKey(p))
                    {
                        dict[p]++;
                    }
                    else
                    {
                        dict[p] = 1;
                    }                        
                }
            }
            return dict.Count;
        }
    }
}