using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Book_IntroductionToAlgorithms
{
    // Not in the book. Just for fun. Found in C0d1l1ty

    // CountingSort strategy:
    // 1. Count how many elements of each type I have
    // 2. Write them (overwrite existing) in the array

    [TestClass]
    public class CountingSort
    {        
        private void Sort(int[] a)
        {
            int k = GetRange(a); // CountingSort requires us to know the range of values

            // count the number of occurences of each number
            var count = new int[k + 1];
            foreach (var i in a) count[i]++;

            // write the numbers in the array
            int p = 0;
            for (int i = 0; i < k + 1; i++)
            {
                for (int j = 0; j < count[i]; j++)
                {
                    a[p] = i;
                    p++;
                }
            }
        }

        private int GetRange(int[] a)
        {
            int max = int.MinValue;
            foreach(var i in a)
            {
                if (i > max) max = i;
            }
            return max;
        }

        [TestMethod]
        public void TestSort()
        {
            var t = new int[] { 5, 2, 7, 4, 3, 1, 30, 50 };
            Sort(t);
        }
    }
}