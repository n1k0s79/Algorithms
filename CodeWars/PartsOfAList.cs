using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWars
{
    /*
     Write a function partlist that gives all the ways to divide a list (an array) of at least two elements into two non-empty parts.

    Each two non empty parts will be in a pair (or an array for languages without tuples or a structin C - C: see Examples test Cases - )
    Each part will be in a string
    Elements of a pair must be in the same order as in the original array.
    Examples of returns in different languages:
    a = ["az", "toto", "picaro", "zone", "kiwi"] -->

    [["az", "toto picaro zone kiwi"], ["az toto", "picaro zone kiwi"], ["az toto picaro", "zone kiwi"], ["az toto picaro zone", "kiwi"]]

    or

    a = {"az", "toto", "picaro", "zone", "kiwi"} -->

    {{"az", "toto picaro zone kiwi"}, {"az toto", "picaro zone kiwi"}, {"az toto picaro", "zone kiwi"}, {"az toto picaro zone", "kiwi"}}

    or

    a = ["az", "toto", "picaro", "zone", "kiwi"] -->

    [("az", "toto picaro zone kiwi"), ("az toto", "picaro zone kiwi"), ("az toto picaro", "zone kiwi"), ("az toto picaro zone", "kiwi")]

    or

    a = [|"az", "toto", "picaro", "zone", "kiwi"|] -->

    [("az", "toto picaro zone kiwi"), ("az toto", "picaro zone kiwi"), ("az toto picaro", "zone kiwi"), ("az toto picaro zone", "kiwi")]

    or

    a = ["az", "toto", "picaro", "zone", "kiwi"] -->

    "(az, toto picaro zone kiwi)(az toto, picaro zone kiwi)(az toto picaro, zone kiwi)(az toto picaro zone, kiwi)"

    You can see other examples for each language in "Your test cases"
    */

    class PartList
    {
        // 0, 1, 2, 3        
        // 0, 1 2 3
        // 0 1, 2 3
        // 0 1 2, 3
        public static string[][] Partlist(string[] arr)
        {
            var ret = new string[arr.Length - 1][];

            for (int i = 0; i < ret.Length; i++)
            {
                var a = MergeElements(arr, 0, i);
                var b = MergeElements(arr, i + 1, arr.Length - 1);
                ret[i] = new string[] { a, b };
            }

            return ret;
        }

        private static string MergeElements(string[] ar, int from, int to)
        {
            var b = new StringBuilder();
            for(int i = from; i <= to; i++) b.Append(ar[i] + " ");
            var ret = b.ToString();
            return ret.Substring(0, ret.Length - 1);
        }
    }
}
