using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math
{
    public class PythagoreanTriplets
    {
        public static IEnumerable<Tuple<int, int, int>> Generate(int maxCount, int maxa = 1000, int maxb = 1000, int maxc = 1000)
        {
            int count = 0;
            int n = 1;
            while (true)
            {
                int m = n + 1;
                while (true)
                {
                    int a = m * m - n * n;
                    int b = 2 * m * n;
                    int c = m * m + n * n;
                    yield return new Tuple<int, int, int>(a, b, c);
                    count++;
                    if (a > maxa || b > maxb || c > maxc) break;
                    m++;
                }
                n++;
                if (count > maxCount) break;
            }
        }
    }
}
