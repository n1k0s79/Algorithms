using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codility
{
    //    Permutation missing element
    //---------------------------
    //Πρέπει να βρω ποιο στοιχείο λείπει από μία διάταξη 1, 2...Ν.Ξέρω ποια στοιχεία πρέπει να έχει η διάταξη.
    //Αν όμως τα ψάξω ένα-ένα θα έχω πολυπλοκότητα Ν^2.
    //Αντ' αυτού, και επειδή ξέρω ΚΑΙ τι άθροισμα πρέπει να έχουν, βρίσκω το άθροισμά τους και το αφαιρώ από το αναμενόμενο άθροισμα
    //(το οποίο είναι Ν(Ν+1)/2).

    [TestClass]
    public class PermMissingElem
    {   
        // Time complexity O(n), space complexity O(1)
        public static long solution(int[] A)
        {
            long sum = 0;
            foreach (var a in A) sum += a;

            long n = A.Length + 1; // if this was int then an overflow would result below
            long sum2;
            checked
            {
                sum2 = n * (n + 1) / 2;
            }            

            long ret = sum2 - sum;
            return ret;
        }

        [TestMethod]
        public void TestSolution()
        {
            //var a = Arrays.Generator.Generate(100000);
            var ret = solution(Missing1001);
        }

        private int[] Missing1001
        {
            get
            {
                var ret = new int[100000];

                int n= 1;
                for (int i=0;i<ret.Length; i++)
                {
                    if (n == 1001) n++;
                    ret[i] = n++;                    
                }

                var a999 = ret[999];
                var a1000 = ret[1000];
                var a1001 = ret[1001];                

                return ret;
            }
        }
    }
}