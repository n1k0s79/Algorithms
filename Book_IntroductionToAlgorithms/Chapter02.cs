using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Book_IntroductionToAlgorithms
{
    [TestClass]
    public class Chapter02
    {
        // Exercise 2.2-1
        // Using Figure 2.2 as a model, illustrate the operation of INSERTION-SORT on the array A { 31, 41, 59, 26, 41, 58 }
        // - Done on paper

        // Exercise 2.1-2
        // Rewrite the INSERTION-SORT procedure to sort into nonincreasing instead of nondecreasing order.
        // - Done

        // Exercise 2.1-3
        // Consider the searching problem:
        // Input: A sequence of n numbers A { a1, a2, ... an } and a value v
        // Output: An index i such that  A[i] = v  or the special value NIL if v does not appear in A.
        // Write pseudocode for linear search, which scans through the sequence, looking for v. 
        // Using a loop invariant, prove that your algorithm is correct.Make sure that your loop invariant fulfills the three necessary properties.

        private static int Search(int[] A, int v)
        {
            int ret = -1; // NIL
            for(int i = 0; i < A.Length; i++)
            {
                if (A[i] == v) return i;
            }

            return ret;
        }

        // ret is the LOOP INVARIANT
        // It will always contain either the value NIL or the searched integer
        // INITIALIZATION:
        // At initialization ret contains the value NIL

        // MAINTENANCE:
        // Loop through each array element. If the element has the searched value then it will be returned
        // If none of the elements has the searched value then ret remains NIL

        // TERMINATION
        // The loop terminates when all the elements have been examined OR if the element has been found
        // ret will either contain NIL or the searched element


        // Exercise 2.1-4
        // Consider the problem of adding two n-bit binary integers, stored in two n-element arrays A and B.
        // The sum of the two integers should be stored in binary form in an (n+1)-element array C. 
        // State the problem formally and write pseudocode for adding the two integers.
        // LOOP INVARIANT: c always contains the sum of the last n digits of a and b
        // INITIALIZATION: for n = 0 , c = 0
        // MAINTENANCE: after each loop c contains the sum of the numbers formed by the last n digits of a and b
        // TERMINATION: the n digits of a and b ARE the same numbers a and b
        // therfore c contains the sum of a and b
        private static int[] AddBin(int[] a, int[] b)
        {
            var c = new int[a.Length + 1];
            
            for (int n = a.Length -1; n >=0; n--)
            {
                // at every iteration store the sum of a[n] + b[n] into c[n + 1]
                // store the carry in c[n]
                int sum = a[n] + b[n] + c[n + 1];
                if (sum < 2)
                {
                    c[n + 1] = sum;
                }
                else
                {
                    c[n + 1] = sum - 2;
                    c[n] = 1;
                }
            }

            return c;
        }

        [TestMethod]
        public void TestSum()
        {
            var c = AddBin(new int[] { 1, 0, 1, 1, 0 }, new int[] { 0, 1, 1, 1, 1 });
        }

        // Exercise 2.2-1
        // Express the function n^3 / 1000 - 100n^2 - 100n + 3 in terms of Θ-notation.
        // Simply Θ(n^3)

        // Exercise 2.2-2
        // Consider sorting n numbers stored in array A by first finding the smallest element
        // of A and exchanging it with the element in AOE1. Then find the second smallest
        // element of A, and exchange it with AOE2. Continue in this manner for the first n1
        // elements of A.Write pseudocode for this algorithm, which is known as selection
        // sort.What loop invariant does this algorithm maintain? Why does it need to run
        // for only the first n - 1 elements, rather than for all n elements? Give the best-case
        // and worst-case running times of selection sort in ‚-notation.
        
        // - Loop invariants written in the code
        // - It runs only for n-1 because as soon as I reach n-1 then I know the last two are sorted
        // Both best case and worst case are Θ(n^2)
        
        //2.2-3
        //Consider linear search again (see Exercise 2.1-3). How many elements of the input
        //sequence need to be checked on the average, assuming that the element being
        //searched for is equally likely to be any element in the array? How about in the
        //worst case? What are the average-case and worst-case running times of linear
        //search in ‚-notation? Justify your answers.
        //2.2-4
        //How can we modify almost any algorithm to have a good best-case running time?

    }
}