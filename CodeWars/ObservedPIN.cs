using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeWars
{
    [TestClass]
    public class ObservedPIN
    {
        /*
        ========
        6/9/2021
        ========
        Alright, detective, one of our colleagues successfully observed our target person, Robby the robber. We followed him to a secret warehouse, where we assume to find all the stolen stuff. The door to this warehouse is secured by an electronic combination lock. Unfortunately our spy isn't sure about the PIN he saw, when Robby entered it.

        The keypad has the following layout:

        ┌───┬───┬───┐
        │ 1 │ 2 │ 3 │
        ├───┼───┼───┤
        │ 4 │ 5 │ 6 │
        ├───┼───┼───┤
        │ 7 │ 8 │ 9 │
        └───┼───┼───┘
            │ 0 │
            └───┘
        He noted the PIN 1357, but he also said, it is possible that each of the digits he saw could actually be another adjacent digit (horizontally or vertically, but not diagonally). E.g. instead of the 1 it could also be the 2 or 4. And instead of the 5 it could also be the 2, 4, 6 or 8.

        He also mentioned, he knows this kind of locks. You can enter an unlimited amount of wrong PINs, they never finally lock the system or sound the alarm. That's why we can try out all possible (*) variations.

        * possible in sense of: the observed PIN itself and all variations considering the adjacent digits

        Can you help us to find all those variations? It would be nice to have a function, that returns an array (or a list in Java and C#) of all variations for an observed PIN with a length of 1 to 8 digits. We could name the function getPINs (get_pins in python, GetPINs in C#). But please note that all PINs, the observed one and also the results, must be strings, because of potentially leading '0's. We already prepared some test cases for you.

        Detective, we are counting on you!

        For C# user: Do not use Mono. Mono is too slower when run your code.
        */

        [TestMethod]
        public void Test()
        {
            var pins = GetPINs("1543");
            CollectionAssert.AreEquivalent(new[] { "5", "7", "8", "9", "0" }, GetPINs("8"));
            CollectionAssert.AreEquivalent(new[] { "11", "22", "44", "12", "21", "14", "41", "24", "42" }, GetPINs("11"));
            CollectionAssert.AreEquivalent(new[] { "339", "366", "399", "658", "636", "258", "268", "669", "668", "266", "369", "398", "256", "296", "259", "368", "638", "396", "238", "356", "659", "639", "666", "359", "336", "299", "338", "696", "269", "358", "656", "698", "699", "298", "236", "239" }, GetPINs("369"));
        }

        public static List<string> GetPINs(string observed)
        {
            var list = new List<string>();
            var initial = string.Join(string.Empty, observed.ToCharArray().Select(c => $"({GetPossibleDigitsAlt(c)})").ToList());
            var l = new List<string>() { initial };
            while (true)
            {
                var f = l.FirstOrDefault(f => f.Contains("("));
                if (f == null) break;                
                var s = f.IndexOf("(");
                var e = f.IndexOf(")");
                var n = f.Substring(s, e - s + 1);
                var previous = f.Substring(0, s);
                l.Remove(f);
                f = f.Substring(e + 1);
                n = n.Replace("(", string.Empty);
                n = n.Replace(")", string.Empty);
                foreach (var c in n) l.Add(previous + c + f);
            }
            return l;
        }

        private static string GetPossibleDigits(char digit)
        {
            //┌───┬───┬───┐
            //│ 1 │ 2 │ 3 │
            //├───┼───┼───┤
            //│ 4 │ 5 │ 6 │
            //├───┼───┼───┤
            //│ 7 │ 8 │ 9 │
            //└───┼───┼───┘
            //    │ 0 │
            //    └───┘

            var dict = new Dictionary<int, int[]>
            {
                { 1, new int[] { 1, 2, 4 } },
                { 2, new int[] { 1, 2, 3, 5 } },
                { 3, new int[] { 2, 3, 6 } },
                { 4, new int[] { 1, 4, 5, 7 } },
                { 5, new int[] { 2, 4, 5, 6, 8 } },
                { 6, new int[] { 3, 5, 6, 9 } },
                { 7, new int[] { 4, 7, 8 } },
                { 8, new int[] { 5, 7, 8, 9, 0 } },
                { 9, new int[] { 6, 8, 9 } },
                { 0, new int[] { 0, 8 } }
            };

            var c = (int)(Char.GetNumericValue(digit));
            return string.Join(string.Empty, dict[c]);
        }

        private static string GetPossibleDigitsAlt(char digit) => new string[] { "08", "124", "1235", "236", "1457", "24568", "3569", "478", "57890", "689", "08" }[digit - '0'];

        /// <summary>
        /// H πιο σύντομη και έξυπνη λύστη από το CodeWars. Ίσως όχι και τόσο ευανάγνωστη
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static List<string> GetPINsAlt(string s) =>
            new[] { "08", "124", "1235", "236", "1457", "24568", "3569", "478", "57890", "689" }[s[0] - '0']
            .SelectMany(c => s.Length > 1 ? GetPINsAlt(s.Substring(1)).Select(p => c + p) : new[] { "" + c }).ToList();
    }
}
