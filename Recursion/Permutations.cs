using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recursion
{
    [TestClass]
    public class Permutations
    {
        [TestMethod]
        public void TestPermutations()
        {
            var permutations1_6 = Permute(new List<int>() { 1, 2, 3 });
            Assert.AreEqual(3, permutations1_6.Count);
            
        }

        public static List<List<T>> Permute<T>(IEnumerable<T> items)
        {
            if (items.Count() == 2) return new List<List<T>>()
                {
                    new List<T> { items.First(), items.Last() },
                    new List<T> { items.Last(), items.First() }
                };
            var perms = new List<List<T>>();
            foreach ( var item in items)
            {
                var restPerms = Permute(items.Except(new[] { item }));
                foreach(var r in restPerms)
                {
                    r.Insert(0, item);
                    perms.Add(r);
                }
            }
            return perms;
        }
    }
}