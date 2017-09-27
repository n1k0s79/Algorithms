using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Strings
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestBetween()
        {
            var s = "fofoofooof";
            var pattern = new Regex("fo+f");
            var l = new List<string>();
            foreach(var m in pattern.Matches(s))
            {
                l.Add(m.ToString());
            }
            

            var k = s.GetBetween("1", "1");
        }
    }
}
