using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codility
{
    //    Odd occurencies
    //----------------------
    // Πρέπει να βρω το στοιχείο σε ένα πίνακα που εμφανίζονται περιττό αριθμό φορές.
    // Έφτιαξα έναν αλγόριμο με λεξικό ο οποίος πήρε σκορ 100%. 
    // Μετά βρήκα κόλπο με XOR.Δεδομένων ότι:
    // - A XOR A = 0
    // - A XOR 0 = A
    // - A XOR B XOR A XOR B XOR C = c

    //Παρατηρώ ότι κάθε XOR αναιρεί το προηγούμενό του.Άρα κάνω XOR και το συνολικό αποτέλεσμα μού αποκαλύπτει τον αριθμό που θέλω.
    //Σημείωση ότι ο αλγόριθμος δε θα δούλευε αν υπήρχαν δύο ή περισσότερα στοιχεία που εμφανίζονται περιττό αριθμό φορές.

   [TestClass]
    public class OddOneOut
    {
        /// <summary> The following code got a 100% result. It's time complexity is O(2*n) and the space complexity is O(d)</summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int solution_mine(int[] A)
        {
            var dict = new Dictionary<int, int>();
            foreach (var i in A)
            {
                if (dict.ContainsKey(i)) dict[i]++; else dict[i] = 1;
            }
            foreach (var kvp in dict)
            {
                if (kvp.Value % 2 == 1) return kvp.Key;
            }

            return 0;
        }

        // Observe that:
        // - A XOR A = 0
        // - A XOR 0 = A
        // - A XOR B XOR A XOR B XOR C = c
        // Each XOR cancels the previous 

        // Time complexity O(n), space complexity O(1)
        public static int solution(int[] A)
        {
            var ret = 0;
            foreach (var i in A) ret ^= i;

            return ret;
        }

        [TestMethod]
        public void TestXor()
        {
            int t = 0;
            foreach(var a in new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 })
            {
                var sa = Convert.ToString(a, 2);
                var ta = Convert.ToString(t, 2);
                t ^= a;
                var tat = Convert.ToString(t, 2);
            }
            var tf = Convert.ToString(t, 2);
        }

        [TestMethod]
        public void TestSolution()
        {
            var a = new int[] { 1, 2, 3, 3, 1 };
            var ret = solution(a);
        }
    }
}