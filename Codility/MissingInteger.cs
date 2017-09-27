using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.LoadTesting; 
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codility
{
    // Πρέπει να βρω το μικρότερο ακέραιο που ΔΕΝ υπάρχει μέσα σε έναν πίνακα από Ν ακεραίους

    [TestClass]
    public class MissingInteger
    {   
        // Άκυρη τελείως αυτή η προσπάθεια. Τελείως λάθος δρόμος...
        public static int solution_wrong(int[] A)
        {
            if (A == null) return -1;
            if (A.Length == 0) return -1;

            Array.Sort(A);
            if (A[0] > 1) return A[0] - 1;

            for (int i = 1; i<A.Length; i++)
            {
                int ai = A[i];
                int ai_1 = A[i - 1];
                int diff = ai - ai_1;
                if (diff > 1) return A[i - 1] + 1;
            }

            return A[A.Length-1] + 1;
        }

        // Απλά τα πράγματα. Με dictionary.
        // Ή αλλιώς θα μπορούσα και με ένα πινακάκι boolean Ν θέσεων (υπάρχει/δεν υπάρχει)
        // και θα ήταν και πιο οικονομικό ΚΑΙ σε χώρο και σε πολυπλοκότητα αφού δεν υπάρχει λόγος να υπολογίζω hash
        public static int solution(int[] A)
        {
            var dict = new Dictionary<int, int>();
            foreach (var a in A) dict[a] = 1;

            int max = int.MinValue;
            for (int i = 1; i <= 100000; i++)
            {
                if (!dict.ContainsKey(i)) return i;
                if (i > max) max = i;
            }

            return max + 1;
        }

        // Τη βρήκα στο ίντερνετ. Δεν καταλαβαίνω γιατί δουλεύει.
        public static int solutionJ(int[] A)
        {
            int[] zeros = new int[A.Length];
            int i = 0;
            for (; i < A.Length; i++)
                if (A[i] <= A.Length && A[i] > 0) zeros[A[i] - 1] = i + 1;

            for (i = 0; i < zeros.Length && zeros[i] != 0; i++) { }

            return i + 1;
        }

        [TestMethod]
        public void TestSolution()
        {
            Assert.AreEqual(5, solutionJ(new int[] { 3, 1, 2, 4, 3, 6}));
            Assert.AreEqual(1, solution(new int[] { 6, 5, 7, 9, 100000 }));
            Assert.AreEqual(2, solution(new int[] { 1 }));
            Assert.AreEqual(11, solution(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }));
            Assert.AreEqual(100001, solution(large_shuffled));
        }

        private static int[] large_shuffled
        {
            get
            {
                var ret = new int[100000];
                for (int i = 0; i< 100000; i++)
                {
                    ret[i] = i + 1;
                }

                ret[2] = 4;
                ret[3] = 3;

                return ret;
            }
        }
    }
}