using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    [TestClass]
    public class CountingValleys
    {
        [TestMethod]
        public void Test()
        {
            var ret = CountValleys("UDDDUDUU");
        }

        public static int CountValleys(string path)
        {
            int lastAlt = 0;
            int ret = 0;
            for (int i = 0; i < path.Length; i++)
            {
                int currAlt = lastAlt;
                if (path[i] == 'U') currAlt++; else currAlt--;
                if (currAlt == 0 && lastAlt == -1) ret++;
                lastAlt = currAlt;
            }

            return ret;
        }
    }
}