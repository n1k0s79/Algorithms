using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Codility
{
    // Πρέπει να δω αν ένας πίνακα με ακεραίους και μήκος Ν είναι διάταξη [1...Ν]
    // 
    [TestClass]
    public class IsPermutation
    {
        // λάθος δρόμος: ξέρω ότι το άθροισμα μιας διάταξης  1,n είναι πάντα n*(n+1)/2
        // όμως μπορεί και ένας άλλος πίνακας με μήκος n να έχει το ίδιο άθροισμα χωρίς να είναι διάταξη
        public static int solution_wrong(int[] A)
        {
            long sum = 0;
            foreach (var a in A) sum += a;

            long n = A.Length;
            long expSum = n * (n + 1) / 2;
            if (sum == expSum) return 1;
            return 0;
        }

        // απλά τα πράγματα: πινακάκι με το οποίο μετράω τις εμφανίσεις κάθε αριθμού
        // πρέπει να είναι ακριβώς μία για όλους
        public static int solution(int[] A)
        {
            var existCount = new int[A.Length];
            foreach (var a in A)
            {
                if (a < 1 || a > A.Length) return 0;
                existCount[a - 1]++;
            }

            if (existCount.Any(x => x != 1)) return 0;
            return 1;
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