using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitManipulation
{
    [TestClass]
    public class Program
    {
        static void Main(string[] args)
        {
        }

        [TestMethod]
        public void Test1()
        {
            //int a = int.MaxValue;
            //var bin = Convert.ToString(a, 2);
            //int b = int.MinValue;
            //bin = Convert.ToString(b, 2);
            //var b1 = Convert.ToString(5, 2);
            //var b2 = Convert.ToString(-1, 2);

            var b = GetNthDigit(5345, 2);
            b = GetNthDigit(5345, 1);
            b = GetNthDigit(5345, 0);

            var temp = Convert.ToString(3904, 2);
            var k = SetNthDigit(3904, 0);
            k = SetNthDigit(k, 1);
            k = SetNthDigit(k, 2);
            k = SetNthDigit(k, 3);
            k = SetNthDigit(k, 4);

            var number = 46783;
            temp = Convert.ToString(number, 2);
            number = ClearNthDigit(number, 2);
            temp = Convert.ToString(number, 2);
        }

        private static byte GetNthDigit(int number, int nth)
        {
            int mask = 1 << nth;
            if ((number & mask) == mask) return 1;
            return 0;
        }

        private static int SetNthDigit(int number, int nth)
        {
            // 100101
            // 010000
            var temp = Convert.ToString(number, 2);
            int mask = 1 << nth;
            return number | mask;
        }

        private static int ClearNthDigit(int number, int nth)
        {
            // 100101
            // 111011            
            int mask = 1 << nth;
            mask = ~mask;
            var snumber = Convert.ToString(number, 2);
            var smask = Convert.ToString(mask, 2);
            return number & mask;
        }
    }
}
