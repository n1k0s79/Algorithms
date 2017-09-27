using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Book_IntroductionToAlgorithms
{
    [TestClass]
    public class SelectionSort
    {
        public enum Order
        {
            NonDescending,
            NonAscending
        }

        public static void Sort(int[] a, Order o)
        {
            for (int j = 0; j < a.Length - 2; j++)
            {
                int key = a[j];
                int minOrMax = o == Order.NonAscending ? int.MinValue : int.MaxValue;
                Func<int, int, bool> f = (x, y) => x < y; // non ascending
                if (o == Order.NonDescending) f = (x, y) => x > y;
                int minOrMaxIndex = 0;
                // find the minimum or maximum in the sequence a[j+1]...a[n]
                for (int i = j + 1; i < a.Length; i++)
                {
                    if (f(minOrMax, a[i]))
                    {
                        minOrMax = a[i];
                        minOrMaxIndex = i;
                    }
                }

                a[j] = a[minOrMaxIndex];
                a[minOrMaxIndex] = key;
            }
        }


        public static void Sort(int[] a)
        {
            // loop invariant: 
            // At the start of this loop the subarray a[0...i-1] contains the smallest elements sorted 
            for (int i = 0; i < a.Length - 2; i++)
            {
                int key = a[i];
                int min = int.MaxValue;
                int minIndex = i;

                // find the minimum in the sequence a[j+1]...a[n]
                // loop invariant: 
                // At the start of this loop a[minIndex] is the smallest number in a[i+1...n]
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[j] < min)
                    {
                        min = a[j];
                        minIndex = j;
                    }
                }

                a[i] = a[minIndex];
                a[minIndex] = key;
            }
        }


        [TestMethod]
        public void TestSort()
        {
            var t = new int[] { 5, 2, 7, 4, 3, 1, -4, 59, -100, 1000 };
            Sort(t, Order.NonDescending);
            Sort(t, Order.NonAscending);
            //Sort(t);
        }
    }
}
