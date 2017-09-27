using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using System.Text;

namespace Euler
{  
    [TestClass]
    public class Problem013_Large_sum
    {    

        [TestMethod]
        public void TestSolution()
        {
            Assert.AreEqual("5537376230", Solution());
        }
    
        public static string Solution()
        {
            var b = new Math.BigInt();
            var lines = System.IO.File.ReadAllLines(@"c:\temp\large_numbers.txt");
            foreach(var l in lines)
            {
                var t = new Math.BigInt(l);
                b += t;
            }
            return b.ToString().Substring(0, 10);
        }
    }
}