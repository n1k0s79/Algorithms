using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Euler
{ 
    [TestClass]
    public class Problem025_1000_digit_Fibonacci_number
    {
        // The Fibonacci sequence is defined by the recurrence relation:

        // Fn = Fn−1 + Fn−2, where F1 = 1 and F2 = 1.

        // Hence the first 12 terms will be:

        //    F1 = 1
        //    F2 = 1
        //    F3 = 2
        //    F4 = 3
        //    F5 = 5
        //    F6 = 8
        //    F7 = 13
        //    F8 = 21
        //    F9 = 34
        //    F10 = 55
        //    F11 = 89
        //    F12 = 144

        //The 12th term, F12, is the first term to contain three digits.

        //What is the index of the first term in the Fibonacci sequence to contain 1000 digits?
        
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual(4782, Solution2());
        }

        // with MY BigInt implementation
        public static int Solution() 
        {
            var n_2 = new Math.BigInt(1);
            var n_1 = new Math.BigInt(1);
            int index = 2;
            while (true)
            {
                index++;
                var n = n_1 + n_2;
                if (n.Value.Length >= 1000) return index;                
                n_2 = n_1;
                n_1 = n;
            }
        }

        // with c#'s big int implementation
        public static int Solution2()
        {
            var n_2 = new System.Numerics.BigInteger(1);
            var n_1 = new System.Numerics.BigInteger(1);
            int index = 2;
            while (true)
            {
                index++;
                var n = n_1 + n_2;
                if (n.ToString().Length >= 1000) return index;
                n_2 = n_1;
                n_1 = n;
            }
        }
    }
}