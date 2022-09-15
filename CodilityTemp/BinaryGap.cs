using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Codility
{
    //    Binary gap
    //------------------------
    // Πρέπει να βρω το μέγιστο αριθμό μηδενικών που περικλείεται από δύο άσσους.Π.χ.στον αριθμό 110010000 πρέπει να επιστρέψω 2
    // Εξετάζω όλους τους χαρακτήρες του αριθμού έναν-έναν
    // - Αν είναι 0 τότε αυξάνω τον τρέχοντα μετρητή μηδενικών
    // - Αν είναι 1 τότε έχω βρει μία αλληλουχία από μηδενικά με μήκος >=0 (μηδέν αν είναι δύο συνεχόμενοι άσσοι)
    // - Ο παραπάνω αλγόριθμος δε με καλύπτει στην περίπτωση που το string που ελέγχω ξεκινά με μηδένικά.
    //  Κάτι τέτοιο όμως δε θα συμβεί γιατί το string προκύπτει πάντα από μετατροπή δεκαδικού.


    [TestClass]
    public class BinaryGap
    {
        public static int solution(int N)
        {
            var s = Convert.ToString(N, 2);

            int count = 0;
            int largestGap = 0;
            foreach (var c in s)
            {
                if (c == '0') count++;
                if (c == '1')
                {
                    if (count > 0)
                    {
                        if (count > largestGap) largestGap = count;
                        count = 0;
                    }
                }
            }
            return largestGap;
        }

        [TestMethod]
        public void TestSolution()
        {
            // basic
            Assert.AreEqual(5, solution(1041)); // 10000010001
            Assert.AreEqual(0, solution(15)); // 1111
            Assert.AreEqual(1, solution(5)); // 101

            // extremes
            Assert.AreEqual(0, solution(1)); // 1            
            Assert.AreEqual(0, solution(2147483647)); // 1111111111111111111111111111111

            // trailing zeroes
            Assert.AreEqual(0, solution(6)); // 110
            Assert.AreEqual(2, solution(328)); // 101001000

            // powers of 2
            Assert.AreEqual(0, solution(16)); // 10000
            Assert.AreEqual(0, solution(1024)); // 10000000000

            // simple
            Assert.AreEqual(2, solution(9)); // 1001
            Assert.AreEqual(1, solution(11)); // 1011
            Assert.AreEqual(2, solution(19)); // 10011
            Assert.AreEqual(1, solution(42)); // 101010
            Assert.AreEqual(3, solution(1162)); // 10010001010

            // medium
            Assert.AreEqual(2, solution(51712)); // 110010100000000
            Assert.AreEqual(1, solution(20)); // 10100

            // medium2
            Assert.AreEqual(3, solution(561892)); // 10001001001011100100

            // medium3
            Assert.AreEqual(9, solution(66561)); // 10000010000000001

            // large1
            Assert.AreEqual(20, solution(6291457)); // 11000000000000000000001

            // large2
            Assert.AreEqual(4, solution(74901729)); // 100011101101110100011100001

            // large3
            Assert.AreEqual(25, solution(805306373)); // 110000000000000000000000000101

            // large4
            Assert.AreEqual(5, solution(1376796946)); // 1010010000100000100000100010010

            // large5
            Assert.AreEqual(29, solution(1073741825)); // 1000000000000000000000000000001

            // large6
            Assert.AreEqual(28, solution(1610612737)); // 1100000000000000000000000000001
        }
    }
}
