using System;
using System.Collections.Generic;

namespace Math
{
    public class Fibonacci
    {
        // ενδιαφέρουσα χρήση του yield return
        // πλην όμως για να κερδίσω τι;
        // κερδίζω μερικές προσθέσεις με κόστος ότι η εκτέλεση του κώδικα δεν είναι γραμμική... μάλλον άσκοπο
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

        public static ulong[] GetFirst()
        {
            var n = new List<ulong>() { 0, 1 };
            while(true)
            {
                checked
                {
                    try
                    {
                        var newFib = n[n.Count - 1] + n[n.Count - 2];
                        n.Add(newFib);
                    }
                    catch (OverflowException x)
                    {
                        return n.ToArray();
                    }
                }                
            }
        }
    }
}
