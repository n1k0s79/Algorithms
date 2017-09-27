using System.Collections.Generic;

namespace Math
{
    public class CollatzSequence
    {
        public readonly List<long> Chain;

        public CollatzSequence(long n)
        {
            Chain = new List<long>();            
            while (n > 1)
            {
                Chain.Add(n);
                checked { if (n % 2 == 0) n /= 2; else n = 3 * n + 1; }
            }
            Chain.Add(n);
        }

        public override string ToString()
        {
            return string.Join("->", Chain.ToArray());
        }

        // cache to get length faster
        private static Dictionary<long, int> dict = new Dictionary<long, int>() { { 1, 1 } };

        public static int GetLength(long n)
        {
            long origin = n;
            int length = 0;
            while (!dict.ContainsKey(n))
            {
                checked
                {
                    if (n % 2 == 0) n /= 2; else n = 3 * n + 1;
                    length++;
                }
            }

            return dict[origin] = length + dict[n];
        }
    }
}