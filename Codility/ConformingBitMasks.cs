using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Codility
{
    /*
     * In this problem we consider unsigned 30-bit integers, i.e. all integers B such that 0 ≤ B < 230.

    We say that integer A conforms to integer B if, in all positions where B has bits set to 1, A has corresponding bits set to 1.

    For example:

    00 0000 1111 0111 1101 1110 0000 1111(BIN) = 16,244,239 conforms to
    00 0000 1100 0110 1101 1110 0000 0001(BIN) = 13,032,961, but
    11 0000 1101 0111 0000 1010 0000 0101(BIN) = 819,399,173 does not conform to
    00 0000 1001 0110 0011 0011 0000 1111(BIN) = 9,843,471.
    Write a function:

    class Solution { public int solution(int A, int B, int C); }

    that, given three unsigned 30-bit integers A, B and C, returns the number of unsigned 30-bit integers conforming to at least one of the given integers.

    For example, for integers:

    A = 11 1111 1111 1111 1111 1111 1001 1111(BIN) = 1,073,741,727,
    B = 11 1111 1111 1111 1111 1111 0011 1111(BIN) = 1,073,741,631, and
    C = 11 1111 1111 1111 1111 1111 0110 1111(BIN) = 1,073,741,679,
    the function should return 8, since there are 8 unsigned 30-bit integers conforming to A, B or C, namely:

    11 1111 1111 1111 1111 1111 0011 1111(BIN) = 1,073,741,631,
    11 1111 1111 1111 1111 1111 0110 1111(BIN) = 1,073,741,679,
    11 1111 1111 1111 1111 1111 0111 1111(BIN) = 1,073,741,695,
    11 1111 1111 1111 1111 1111 1001 1111(BIN) = 1,073,741,727,
    11 1111 1111 1111 1111 1111 1011 1111(BIN) = 1,073,741,759,
    11 1111 1111 1111 1111 1111 1101 1111(BIN) = 1,073,741,791,
    11 1111 1111 1111 1111 1111 1110 1111(BIN) = 1,073,741,807,
    11 1111 1111 1111 1111 1111 1111 1111(BIN) = 1,073,741,823.
    Write an efficient algorithm for the following assumptions:

    A, B and C are integers within the range [0..1,073,741,823].
     */

    // 2/9/2022
    // Αυτό με δυσκόλεψε
    // 1. κάνοντας λογικό ΚΑΙ (AND) τους τρεις αριθμούς δεν οδηγούμαι πουθενά
    // 2. είναι εύκολονα υπολογίσω πόσοι αριθμοί ταιριάζουν με τη μάσκα, είναι 2 εις την (το πλήθος των 0)
    // 3. αν προσθέσω όμως τα τρια αυτά πλήθη παίρνω (δυνητικά) λάθος αποτέλεσμα γιατί κάποιοι αριθμοί έχουν μετρηθεί δύο ή και τρεις φορές εφόσον ταιριάζουν σε δύο ή τρεις μάσκες
    // 4. μία λύση (solution_firstTry) είναι να προσπαθήσω να βρω όχι μόνο το πλήθος των αριθμών που ταιριάζουνε στη μάσκα αλλά τους ίδιους τους αριθμούς
    //    αυτό δουλεύει καλά αν το πλήθος είναι μικρό αλλά αν το πλήθος είναι μεγάλο αργεί πάρα πολύ
    // 5. άρα θα προσπαθήσω να βρω πόσους αριθμούς μέτρησα πάνω από μία φορά και να αφαιρέσω το πλήθος τους από το βήμα 3
    // 6. αν δύο μάσκες έχουν Ν κοινά μηδενικά τότε έχουν 2 ^ Ν κοινούς αριθμούς που ταιριάζουνε
    //    παίρνω λοιπόν τους συνδυασμούς των μασκών ανά δύο και βρίσκω το πλήθος των κοινών και το αφαιρώ
    // 7. ΠΡΟΣΟΧΗ όμως: ο αριθμός 111111111111... πάντοτε ταιριάζει στη μάσκα, και τον έχω αφαιρέσει τρεις φορές γιατί είναι πάντοτε κοινός με όλους τους συνδυασμούς
    //    τη μία από αυτές τις τρεις, τον θέλω
    [TestClass]
    public class ConformingBitmasks
    {     
        public static int solution(int A, int B, int C)
        {
            var totalWithDuplicates = new int[] { A, B, C }.Select(x => GetNrOfConforming(x)).Sum();
            var common1 = GetNrOfConforming(A | B);
            var common2 = GetNrOfConforming(A | C);
            var common3 = GetNrOfConforming(C | B);
            var ret = totalWithDuplicates - common1 - common2 - common3 + 1;
            return ret;
        }

        private static int solution_firstTry(int A, int B, int C)
        {
            var c1 = GetConforming(A);
            var c2 = GetConforming(B);
            var c3 = GetConforming(C);
            var all = c1.Union(c2).Union(c3).ToList();
            return all.Count;
        }

        private static int[] GetConforming(int mask)
        {
            var conforming = new List<int>();
            var test = mask;
            var max = (int)System.Math.Pow(2, 30);
            while (test < max)
            {
                if ((test & mask) == mask) conforming.Add(test);
                test += 1;
            }
            return conforming.ToArray();
        }

        private static int GetNrOfConforming(int a)
        {
            var s = System.Convert.ToString(a, 2);
            var zeros = CountZeros(a);
            return (int)System.Math.Pow(2, zeros);
        }

        private static bool ConformsToAnyOf(int test, int a, int b, int c)
        {
            return Conforms(test, a) || Conforms(test, b) || Conforms(test, c);
        }

        private static bool Conforms(int a, int b)
        {
            var bina = System.Convert.ToString(a, 2);
            var binb = System.Convert.ToString(b, 2);
            var binc = System.Convert.ToString(a & b, 2);
            var ret = (a & b) == b;
            return ret;
        }

        private static int CountZeros(int a) => System.Convert.ToString(a, 2).Count(c => c == '0');

        private static int GetNrOfCommonConforming(int a, int b)
        {
            var zeros = CountZeros(a & b);
            return (int)System.Math.Pow(2, zeros);
        }

        [TestMethod]
        public void TestSolution()
        {
            var t = solution(1073741727, 1073741631, 1073741679);            
            var k = Conforms(5, 4);
        }
    }
}