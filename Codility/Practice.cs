using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility
{
    /*
     * This is a demo task.

    Write a function:

    class Solution { public int solution(int[] A); }

    that, given an array A of N integers, returns the smallest positive integer (greater than 0) that does not occur in A.

    For example, given A = [1, 3, 6, 4, 1, 2], the function should return 5.

    Given A = [1, 2, 3], the function should return 4.

    Given A = [−1, −3], the function should return 1.

    Write an efficient algorithm for the following assumptions:

    N is an integer within the range [1..100,000];
    each element of array A is an integer within the range [−1,000,000..1,000,000].
    Copyright 2009–2022 by Codility Limited. All Rights Reserved. Unauthorized copying, publication or disclosure prohibited.
     */

    [TestClass]
    public class Practice {
        public int solution(int[] A)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < A.Length; i ++)
            {
                if (!dict.ContainsKey(A[i])) dict.Add(A[i], 1); else dict[A[i]]++;                
            }
            for (int i = 1; i < 1000001; i++)
            {
                if (!dict.ContainsKey(i)) return i;
            }
            return 1;
        }


        [TestMethod]
        public void TestSolution()
        {
            var testArray1 = new int[] { 1, 3, 6, 4, 1, 2 };
            var k = solution(testArray1);

        }


    }
}
