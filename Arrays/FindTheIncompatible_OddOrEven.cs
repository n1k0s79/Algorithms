using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    /// <summary>
    /// Given an array of integers find the one that is not compatible with the others in terms of odds/evens
    /// </summary>
    public class FindTheIncompatible_OddOrEven
    {
        public static int Find(int[] integers)
        {
            int odds = 0;
            int evens = 0;
            int lastodd = 0;
            int lasteven = 0;

            foreach (var t in integers)
            {
                if (t % 2 == 0)
                {
                    evens++;
                    lasteven = t;
                }
                else
                {
                    odds++;
                    lastodd = t;
                }

            }

            if (evens >= 2) return lastodd;
            else return lasteven;
        }
    }
}
