using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeWars
{
    [TestClass]
    public class Intervals
    {
        [TestMethod]
        public void Test()
        {
            var input = new (int, int)[] { (1, 5), (10, 17) };
            var j = SumIntervals(input);
        }


        [TestMethod]
        public void Test1()
        {
            var input = new (int, int)[] { (1, 2), (6, 10), (11, 15) };
            var result = SumIntervals(input);
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void Test2()
        {
            var input = new (int, int)[] { (1, 4), (7, 10), (3, 5) };
            var result = SumIntervals(input);
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void Test3()
        {
            var input = new (int, int)[] { (1, 5), (10, 20), (1, 6), (16, 19), (5, 11) };
            var result = SumIntervals(input);
            Assert.AreEqual(19, result);
        }

        // Η λύση μου
        public static int SumIntervals((int, int)[] intervals)
        {
            var items = intervals.Select(i => new Interval(i)).ToList();
            var newList = new List<Interval>();
            foreach(var item in items)
            {
                var overlapping = newList.Where(i => i.GetOverlap(item) != null).ToList();
                if (overlapping.Any())
                {
                    overlapping.ToList().ForEach(o => newList.Remove(o));
                    var merged = Interval.Merge(overlapping.Concat(new Interval[] { item }).ToArray());
                    newList.Add(merged);
                }
                else
                {
                    newList.Add(item);
                }
            }
            var ret = newList.Sum(i => i.Length);
            return ret;
        }

        [DebuggerDisplay("{From}-{To}")]
        class Interval
        {
            public int From;
            public int To;
            public Interval(int from, int to)
            {
                From = from;
                To = to;
            }

            public Interval((int, int) couple)
            {
                From = couple.Item1;
                To = couple.Item2;
            }

            public int Length => To - From;
            public Interval GetOverlap(Interval other)
            {
                var from = Math.Max(From, other.From);
                var to = Math.Min(To, other.To);
                return from > to ? null : new Interval(from, to);
            }

            public static Interval Merge(params Interval[] items) => items.Aggregate((a, b) => a.MergeWith(b));

            public Interval MergeWith(Interval other)
            {
                var from = Math.Min(From, other.From);
                var to = Math.Max(To, other.To);
                return new Interval(from, to);
            }

            public static Interval GetOverlap(params Interval[] intervals) => intervals.Aggregate((a, b) => a.GetOverlap(b));
        }

        /// <summary> Αυτή τη λύση τη βρήκα στο codewars 
        /// Πώς δουλεύει και γιατί; </summary>
        public static int SumIntervals2((int min, int max)[] intervals)
        {
            var prevMax = int.MinValue;

            return intervals
                .OrderBy(x => x.min)
                .ThenBy(x => x.max)
                .Aggregate(0, (acc, x) => acc += prevMax < x.max ? -Math.Max(x.min, prevMax) + (prevMax = x.max) : 0);
        }
    }
}
