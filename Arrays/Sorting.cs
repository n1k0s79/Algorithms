using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Arrays
{
    [TestClass]
    public class Sorting
    {
        [TestMethod]
        public void TestInsertionSort()
        {
            var a = new [] {6, 5, 4, 3, 2, 1};
            InsertionSort(a);
        }

        public static void InsertionSort(int[] a)
        {
            for (int j = 1; j < a.Length; j++)
            {
                var current = a[j];
                int i = j - 1; // the previous index

                // all items to the left should be less than the current
                // so move all greater items to the right
                while (i >= 0 && a[i] > current)
                {
                    a[i + 1] = a[i]; 
                    i--;
                }
                a[i + 1] = current;
            }
        }
    }
}