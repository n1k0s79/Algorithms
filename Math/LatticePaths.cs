namespace Math
{
    public class LatticePaths
    {
        public static long Calculate(int n)
        {
            // the number of paths to go to a specific point is the number of paths of its adjacent (left and up) points
            var a = new long[n + 1, n + 1];
            for (int row = 0; row < n + 1; row++) a[row, 0] = 1;
            for (int col = 0; col < n + 1; col++) a[0, col] = 1;
            for (int row = 1; row < n + 1; row++)
            {
                for (int col = 1; col < n + 1; col++)
                {
                    long left = a[row - 1, col];
                    long up = a[row, col - 1];
                    if (a[row, col] == 0) checked { a[row, col] = left + up; }
                }
            }
            return a[n, n];
        }
    }
}