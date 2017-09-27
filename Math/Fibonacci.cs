using System;
using System.Collections.Generic;

namespace Math
{
    public class Fibonacci
    {
        public static IEnumerable<ulong> GenerateFirst(int n)
        {
            if (n > 91) throw new Exception("The 92nd Fibonacci is too large for ulong! Can only calculate up to the 91st.");
            ulong prevFib = 1;
            yield return prevFib;
            ulong lastFib = 2;
            int count = 1;
            while (count < n)
            {
                yield return lastFib;
                ulong temp = lastFib;
                checked { lastFib = prevFib + lastFib; }
                prevFib = temp;
                count++;
            }
        }
    }
}
