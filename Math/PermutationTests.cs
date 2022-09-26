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
            var myPerms = GetAllPermutations(a);
            var linqPerms = Permutation.GetAll(a).ToList();
            for (int i = 0; i < linqPerms.Count; i++) Assert.IsTrue(myPerms[i].SequenceEqual(linqPerms[i]));
        }        

        /// <summary> H δική μου συνάρτηση για τις μεταθέσεις. (26/9/2022) 
        /// 20 γραμμές κώδικα αντί 2 του linq
        /// </summary>
        public static List<List<T>> GetAllPermutations<T>(List<T> list)
        {
            if (list.Count == 2)
            {
                return new List<List<T>>() { new List<T>() { list[0], list[1] }, new List<T>() { list[1], list[0] } };
            }
            var currentLists = new List<List<T>>();
            foreach (var head in list)
            {
                var tail = list.Except(new T[] { head }).ToList();
                var prevPermutations = GetAllPermutations(tail);
                foreach (var prevPerm in prevPermutations)
                {
                    var newList = new List<T>() { head };
                    newList.AddRange(prevPerm);
                    currentLists.Add(newList);
                }
            }
            return currentLists;
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