using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Codility
{
    // Πρέπει να βρω τη "φέτα" του πίνακα με το μικρότερο μέσο όρο 
    // Είναι εύκολο να βρω το άθροισμα και το μέσο όρο μιας φέτας με χρήση των prefix sums
    // Όμως επειδή το πλάτος της φέτας δεν είναι συγκεκριμένο πρέπει να ψάξω όλα τα πιθανά πλάτη
    // Αυτό δίνει πολυπλοκότητα Ν^2
    // Και πράγματι δεν υπάρχει λύση με πολυπλοκότητα Ν αν κάποιος δεν ξέρει ότι το μέγιστο πλάτος φέτας 
    // δε μπορεί να είναι μεγαλύτερο από 3
    // Πώς μπορώ να το παρατηρήσω αυτό;

    [TestClass]
    public class MinAvgTwoSlice
    {   
        public static int solution(int[] A)
        {
            double min = int.MaxValue;
            int foundIndex = -1;

            var prefix = GetPrefixSums(A);
            for (int startIndex = 0; startIndex < A.Length - 1; startIndex++)
            {
                for (int sliceSize = 2; sliceSize < A.Length - startIndex + 1; sliceSize++)
                {
                    var avg = GetSliceAvg(prefix, startIndex, startIndex + sliceSize - 1);
                    if (avg < min)
                    {
                        min = avg;
                        foundIndex = startIndex;
                    }
                }
            }

            return foundIndex;
        }

        // observation that max slice length is 3
        public static int solution_afterobservation(int[] A)
        {
            double min = int.MaxValue;
            int foundIndex = -1;

            var prefix = GetPrefixSums(A);
            for (int startIndex = 0; startIndex < A.Length - 1; startIndex++)
            {
                var maxSliceSize = 2;
                if (startIndex < A.Length - 2) maxSliceSize = 3;

                for (int sliceSize = 2; sliceSize <= maxSliceSize; sliceSize++)
                {
                    var avg = GetSliceAvg(prefix, startIndex, startIndex + sliceSize - 1);
                    if (avg < min)
                    {
                        min = avg;
                        foundIndex = startIndex;
                    }
                }
            }

            return foundIndex;
        }

        private static int GetSliceSum(long[] prefix, int p, int q)
        {
            if (p == 0) return (int)prefix[q];
            return (int)(prefix[q] - prefix[p-1]);
        }

        private static double GetSliceAvg(long[] prefix, int p, int q)
        {
            var sum = (double)GetSliceSum(prefix, p, q);
            var length = (double)(q - p + 1);
            var ret = sum / length;
            return ret;
        }

        private static long[] GetPrefixSums(int[] A)
        {
            var ret = new long[A.Length];
            long prefixSum = 0;
            for (int i = 0; i < A.Length; i++)
            {
                prefixSum += A[i];
                ret[i] = prefixSum;
            }

            return ret;
        }

        [TestMethod]
        public void TestSolution()
        {
            var a = new int[] { 12, 7, 1, 67, 4, 2, 1, 2 };
            //var b = new int[] { 4, 2, 2, 5, 1, 5, 8 };
            var t = solution_afterobservation(a);
        }
    }
}