using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codility
{
    // Πρέπει να βρω το πλήθος των αριθμών που βρίσκονται μεταξύ Α και Β (συμπεριλαμβανομένων) και διαιρούνται ακριβώς με Κ

    // π.χ. Κ = 3 και μέγιστο = 16
    // 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 
    //     *     *     *        *        *

    // 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 
    //     *     *     *        *        *        *       *
    // Παρατηρώ ότι το πλήθος των αριθμών που διαιρούνται με 3 και είναι μιρκότεροι από Ν είναι Ν/3 όπου '/' μου δίνει μόνο το πηλίκο
    // άρα πλήθος = Ν / Κ

    // για να βρω επομένως το πλήθος των αριθμών μεταξύ Α και Β που διαιρούνται με Κ αφαιρώ τα δύο πλήθη
    // επειδή όμως περιλαμβάνεται το Α, ελέγχω αν αυτό διαιρείται ακριβώς και αν ναι τότε προσθέτω ένα

    [TestClass]
    public class CountDiv
    {     
        public static int solution(int A, int B, int K)
        {
            // the number of integers <= N that are divisible by K is N / K
            // so to calculate the number of integers between A and B that are divisble by K subtract below A from below B
            int belowB = B / K;
            int belowA = A / K;
            var dif = belowB - belowA;
            if (A % K == 0) dif++; // if A is evenly divided by K then I need one more number
            return dif;
        }

        [TestMethod]
        public void TestSolution()
        {
            var s = solution(6, 11, 2);
        }
    }
}