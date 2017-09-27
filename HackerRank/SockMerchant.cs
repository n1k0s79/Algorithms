using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    [TestClass]
    public class SockMerchant
    {

        [TestMethod]
        public void Test()
        {
            var dict = new Dictionary<int, int>();

            string[] ar_temp = "44 55 11 15 4 72 26 91 80 14 43 78 70 75 36 83 78 91 17 17 54 65 60 21 58 98 87 45 75 97 81 18 51 43 84 54 66 10 44 45 23 38 22 44 65 9 78 42 100 94 58 5 11 69 26 20 19 64 64 93 60 96 10 10 39 94 15 4 3 10 1 77 48 74 20 12 83 97 5 82 43 15 86 5 35 63 24 53 27 87 45 38 34 7 48 24 100 14 80 54"
                .Split(' ');
            int[] ar = Array.ConvertAll(ar_temp, Int32.Parse);

            foreach (var i in ar)
            {
                int count = 0;
                dict.TryGetValue(i, out count);                
                dict[i] = count + 1;
            }

            int ret = 0;
            foreach(var kvp in dict) ret += kvp.Value / 2;
            Assert.AreEqual(30, ret);
        }

        // test input : 44 55 11 15 4 72 26 91 80 14 43 78 70 75 36 83 78 91 17 17 54 65 60 21 58 98 87 45 75 97 81 18 51 43 84 54 66 10 44 45 23 38 22 44 65 9 78 42 100 94 58 5 11 69 26 20 19 64 64 93 60 96 10 10 39 94 15 4 3 10 1 77 48 74 20 12 83 97 5 82 43 15 86 5 35 63 24 53 27 87 45 38 34 7 48 24 100 14 80 54
        // expected output: 30 
    }
}
