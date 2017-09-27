using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codility
{
    //    Tape equilibrium
    //---------------------------
    //Πρέπει βρω τον index του πίνακα ο οποίος τον χωρίζει κατα το δυνατότ σε δύο μέρη ίσου αθροίσματος.
    //Βρίσκω επομένως την ελάχιστη διαφορά των δύο μερών.
    //Για να βρω το άθροισμα του δεύτερου μέρους αφαιρώ από το άθροισμα όλων των στοιχείων το άθροισμα του πρώτου μέρους (prefix sums)
    //Έτσι πάω από Ν^2 σε 2Ν πολυπλοκότητα

    [TestClass]
    public class TapeEquilibrium
    {   
        public static int solution(int[] A)
        {
            int sum = 0;
            // sum all the elements in the array
            foreach (var a in A) sum += a;

            int tempSum = 0;
            int minDiff = int.MaxValue;
            for (int i = 0; i < A.Length -1; i++)
            {
                tempSum += A[i]; // sum of the first part
                int secondPart = sum - tempSum; // sum of the second part
                int diff = Math.Abs(tempSum - secondPart);
                if (diff < minDiff) minDiff = diff;
            }

            return minDiff;
        }

        [TestMethod]
        public void TestSolution()
        {
            //var a = new int[] { 3, 1, 2, 4, 3};
            var a = new int[] { 60, 40 };
            var ret = solution(a);
        }
    }
}