using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeWars
{
    [TestClass]
    public class Isograms
    {
        /*
        An isogram is a word that has no repeating letters, consecutive or non-consecutive. Implement a function that determines whether a string that contains only letters is an isogram. Assume the empty string is an isogram. Ignore letter case.
        isIsogram "Dermatoglyphics" == true
        isIsogram "aba" == false
        isIsogram "moOse" == false -- ignore letter case
         */

        [TestMethod]
        public void Test()
        {
            Assert.IsTrue(IsIsogram("Dermatoglyphics"));
            Assert.IsFalse(IsIsogram("aba"));
            Assert.IsFalse(IsIsogram("moOse"));
        }

        public static bool IsIsogram(string str) => !str.ToLowerInvariant().ToCharArray().GroupBy(c => c).Any(g => g.Count() > 1);

        public static bool IsIsogramAlt(string str) => str.ToLower().Distinct().Count()==str.Length;
    }
}
