using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Book_IntroductionToAlgorithms
{
    [TestClass]
    public class InsertionSort
    {
        public enum Order
        {
            NonDescending,
            NonAscending
        }

        public static void Sort(int[] a, Order o)
        {
            for(int j = 1; j<a.Length; j++)
            {
                int key = a[j];     // grab each element and store it in this variable. I'll need this later
                int i = j - 1;      // compare this with its previous

                Func<int, int, bool> f = (x, y) => { return x > y; };
                if (o == Order.NonAscending) f = (x, y) => { return x < y; };

                while (i >= 0 && f(a[i],key))    // if the previous element is greater/smaller then I need to:
                {
                    a[i + 1] = a[i];            // move all the guys one position to the right
                    i--;
                }
                a[i + 1] = key;                 // and place the key in the just right position
            }
        }

        [TestMethod]
        public void TestSort()
        {
            var t = new int[] { 5, 2, 7, 4, 3 };
            Sort(t, Order.NonDescending);
            Sort(t, Order.NonAscending);
        }
    }
}
