using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Math
{

    [TestClass]
    public class PermutationTests
    {
        [TestMethod]
        public void Simplest()
        {
            var a = new char[] { 'a', 'b', 'c', 'd' }.ToList();
            var myPerms = Permutation.GetAllPermutations(a);
            var linqPerms = Permutation.GetAllΤ(a).ToList();
            for (int i = 0; i < linqPerms.Count; i++) Assert.IsTrue(myPerms[i].SequenceEqual(linqPerms[i]));
        }

        [TestMethod]
        public void PermsPerN()
        {
            var a = new int[] { 1, 2, 3, 4, 5 };
            var myPerms = Permutation.GetAll(a, 3).ToList();
        }

        [TestMethod]
        public void Test()
        {
            var items = Permutation<int>.GetAllPossible(1, 2, 3, 4);
            Assert.AreEqual(24, items.Count);
            var j = GetPINs("1674");
            var k = GetPINs("4");
            var all = Permutation.GetAllPositional(new List<List<char>>() { new List<char> { 'a', 'b', 'c' }, new List<char> { '1', '2', '3' } });

            var permutations = all.Select(l => new string(l.ToArray())).ToList();
            var joined = string.Join(", ", permutations);
            Assert.AreEqual("a1, a2, a3, b1, b2, b3, c1, c2, c3", joined);

            var all2 = Permutation.GetAllPositional(new List<List<char>>() { new List<char> { 'a', 'b', 'c' }, new List<char> { '1', '2' } });
            var jj = Stringify(Permutation.GetAll(new char[] { 'a', 'b', 'c', 'd' }, 2));
            var j1 = Stringify(Permutation.GetAll(new char[] { 'a', 'b', 'c', 'd' }, 3));
            var j2 = Stringify(Permutation.GetAll_E(new char[] { 'a', 'b', 'c', 'd' }));
        }

        private static string Stringify<T>(IEnumerable<IEnumerable<T>> listOfLists) => 
            string.Join(", ", listOfLists.Select(l => string.Join(string.Empty, l.Select(o => o.ToString()))));

        //public static List<string> GetPINs(string s)
        //{
        //    var digits = new[] { "08", "124", "1235", "236", "1457", "24568", "3569", "478", "57890", "689" };
        //    if (s.Length == 1) return digits[s[0] - '0'].Select(c => c.ToString()).ToList();
        //    //var head = digits[s[0] - '0'];
        //    //var tail = s.Substring(1);
        //    //foreach (var c in head)
        //    //{
        //    //    if (s.Length > 1)
        //    //    {
        //    //        var tail = s.Substring(1);
        //    //        var list = new List<string>();
        //    //        return tail.Select(p => c + p).ToList();

        //    //    }
        //    //    else
        //    //    {
        //    //        return new[] { "" + c }.ToList();
        //    //    }
        //    //}
        //    //return head.SelectMany(c => s.Length > 1 ? GetPINs(s.Substring(1)).Select(p => c + p) : new[] { "" + c }).ToList();
        //    return null;
        //}

        private static string[] digits = new[] { "08", "124", "1235", "236", "1457", "24568", "3569", "478", "57890", "689" };
        public static List<string> GetPINs(string s)
        {
            return digits[s[0] - '0'].SelectMany(c => s.Length > 1 ? GetPINs(s.Substring(1)).Select(p => c + p) : new[] { c.ToString() }).ToList();
        }
    }
}