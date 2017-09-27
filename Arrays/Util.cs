using System;
using System.Collections.Generic;

namespace Arrays
{
    public class Util
    {
        public static void Reverse<T>(T[] a)
        {
            Reverse(a, 0, a.Length - 1);
        }

        public static void Reverse<T>(T[] a, int start)
        {
            Reverse(a, start, a.Length - 1);
        }

        public static void Reverse<T>(T[] a, int start, int end)
        {
            while (start < end)
            {
                SwapElements(a, start, end);
                start++;
                end--;
            }
        }

        public static void SwapElements<T>(T[] a, int i, int j)
        {
            T temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        public static string ArrayToString<T>(T[] a)
        {
            var stringArray = Array.ConvertAll(a, x => x.ToString());
            return string.Join(" ", stringArray);
        }

        public static string ArrayToString<T>(T[,] a, int pad = 0)
        {
            var ret = "";
            for (int row = 0; row < a.GetLength(0); row++)
            {
                var l = new List<string>();
                for (int col = 0; col < a.GetLength(1); col++)
                {
                    string s = a[row, col].ToString();
                    if (pad > 0) s = s.PadLeft(pad, ' ');
                    l.Add(s);
                }

                ret += string.Join(" ", l) + "\n";
            }
            return ret;
        }
    }
}