using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Euler
{
   [TestClass]
    public class Problem028_Number_spiral_diagonals
    {
        [TestMethod]
        public void TestIt()
        {
            var s = GetSpiral(1001);
            var sum = GetDiagonalSum(s);
            Assert.AreEqual(669171001, sum);
        }
        
        private static long GetDiagonalSum(int[,] a)
        {
            long sum = 0;
            var l = a.GetLength(1);
            for(int i = 0; i < l; i++) sum += a[i, i];
            for (int i = 0; i < l; i++) sum += a[i, l - i - 1];
            return sum - 1;
        }

        private static int[,] GetSpiral(int d)
        {
            var ret = new int[d, d];
            int m = d / 2;
            ret[m, m] = 1;
            var row = m;
            var col = m;
            int lastN = 2;

            // fill spiral
            col++;
            for (int i=3; i <= d; i+=2)
            {
                FillPerimeter(ref ret, i, ref row, ref col, ref lastN);                
            }            

            return ret;
        }

        private static void FillPerimeter(ref int [,] a, int edgeItems, ref int row, ref int col, ref int itemNr)
        {
            for (int x = 0; x < edgeItems - 1; x++) a[row++, col] = itemNr++;
            row--;
            itemNr--;

            for (int x = 0; x < edgeItems - 1; x++) a[row, col--] = itemNr++;
            for (int x = 0; x < edgeItems - 1; x++) a[row--, col] = itemNr++;
            for (int x = 0; x < edgeItems; x++) a[row, col++] = itemNr++;
        }
    }
}