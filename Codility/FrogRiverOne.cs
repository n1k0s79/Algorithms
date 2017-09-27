using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codility
{
    [TestClass]
    public class FrogRiverOne
    {   
        // Time complexity O(n), space complexity O(1)
        public static int solution(int[] A, int X)
        {
            var dict = new Dictionary<int, bool>();
            long expSum = (long)X * ((long)X + 1) / 2;
            long sum = 0;
            for (int i = 0; i< A.Length; i++)
            {
                int a = A[i];
                if (!dict.ContainsKey(a))
                {
                    dict[a] = true;
                    sum += a;
                    if (sum == expSum) return i;
                }                
            }

            return -1;
        }

        [TestMethod]
        public void TestSolution()
        {
            var a = new int[] { 1, 3, 1, 4, 2, 3, 5, 4 };
            Assert.AreEqual(-1, solution(new int[] { 1, 2, 1, 2, 1, 2 }, 3)); // leaves are never enough
        }
    }
}