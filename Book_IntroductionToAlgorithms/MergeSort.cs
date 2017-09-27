using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Book_IntroductionToAlgorithms
{
    [TestClass]
    public class MergeSort
    {        
        private void Merge(int[] a, int p, int q, int s)
        {            
            var leftArray = GetSubArray(a, p, q);       // auxiliary space needed here... The cost of n*log(n)...
            var rightArray = GetSubArray(a, q+1, s);

            int index = p;
            int leftIndex = 0;
            int rightIndex = 0;

            // take the smallest of the two (if there exist two elements)
            // if not take what exists
            while(index <= s)
            {
                if (leftIndex >= leftArray.Length)
                {
                    a[index++] = rightArray[rightIndex];
                    rightIndex++;
                }
                else if (rightIndex >= rightArray.Length)
                {
                    a[index++] = leftArray[leftIndex];
                    leftIndex++;
                }
                else
                {
                    int left = leftArray[leftIndex];
                    int right = rightArray[rightIndex];
                    if (left <= right)
                    {
                        a[index++] = left;
                        leftIndex++;
                    }
                    else
                    {
                        a[index++] = right;
                        rightIndex++;
                    }
                }
            }
        }

        private int[] GetSubArray(int[] a, int p, int q)
        {
            var ret = new int[q - p + 1];
            int j = 0;
            for (int i = p; i <= q; i++) ret[j++] = a[i];
            return ret;
        }

        private void Sort(int[] a)
        {
            Sort(a, 0, a.Length - 1);
        }

        private static int iterations = 0;

        private void Sort(int[] a, int p, int r)
        {
            //Debug.Write(string.Format("Sorting {0},{1}...", p, r));
            if (p == r)
            {
                //Debug.WriteLine(" Sorted!");
                return;
            }

            //Debug.WriteLine("");

            iterations++;
            
            int q = (p + r)/ 2;

            Sort(a, p, q);
            Sort(a, q + 1, r);

            Debug.WriteLine("Merging {0},{1} with {2},{3}...", p, q, q + 1, r);
            Merge(a, p, q, r);
        }

        [TestMethod]
        public void TestSort()
        {
            var t = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            //var t = new int[] { 3, 9, 10, 11, 1, 5, 8, 9, 12, 1, 30, 2, 5, 77, 3, 123, 1, -5, -66, 5, 3, 4 };
            Sort(t);
        }
    }
}