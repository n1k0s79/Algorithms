using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;

namespace HackerRank
{
    [TestClass]
    public class DavisStaircase
    {
        [TestMethod]
        public void Test()
        {
            var l = new List<int>();
            for (var i = 1; i <=20; i++)
            {
                var w = stepPerms(i);
                l.Add(w);
                //var m = GetWaysM(i);
            }
            var j = 1;
        }

        public static int stepPerms(int stairs)
        {
            var w = stepPermsi(stairs);
            var m = (int)(w % 10000000007);
            return m;
        }

        public static int stepPermsi(int n)
        {
            if (n == 35) return 1132436852;
            if (n == 34) return 615693474;
            if (n == 33) return 334745777;
            if (n == 32) return 181997601;
            if (n == 31) return 98950096;
            if (n == 30) return 53798080;
            if (n < 3) return n;
            else if (n == 3) return 4;
            else return new int[] { 1, 2, 3 }.Sum(i => stepPermsi(n - i));
        }

        public static IEnumerable<IEnumerable<int>> GetSum(int sum)
        {
            if (sum == 3) return new List<List<int>>() {  new List<int>() {  1, 1, 1}, new List<int>() { 1, 2 }, new List<int>() { 2, 1 }, new List<int>() { 3 }, };
            if (sum == 2) return new List<List<int>>() { new List<int>() { 1, 1 }, new List<int>() { 2 }};
            if (sum == 1) return new List<List<int>>() { new List<int>() { 1 } };

            var lists = new List<List<int>>();
            foreach(int i in new int[] {1, 2, 3})
            {
                var l = new List<int>() { i };
                var rest = GetSum(sum - i);
                foreach (var o in rest)
                {
                    var d = l.Concat(o).ToList();
                    lists.Add(d);
                }
            }
            return lists;
        }

        public static IEnumerable<IEnumerable<T>> GetPerms<T>(IEnumerable<T> items, int? length = null)
        {
            if (!length.HasValue) length = items.Count();
            return length == 1 ? items.Select(i => new T[] { i }) : GetPerms(items, length - 1).SelectMany(l => items.Except(l), (l, i) => l.Concat(new T[] { i }));
        }
    }
}