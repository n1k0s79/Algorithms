using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Data.SqlTypes;

namespace RemoteInterview
{
    [TestClass]
    public class ConformingBitmasks
    {     

        [TestMethod]
        public void Test()
        {
            var numbers = new int[] { 6, 1, 5, 2, 9 };
            var k = GetIncreasingSequences(numbers);
        }

        private static int[] GetIncreasingSequences(int[] numbers) =>
            numbers.Aggregate(new List<int>(), (seq, i) =>
            {
                if (seq.Count == 0)
                {
                    seq.Add(i);
                    return seq;
                }
                if (i < seq.Last())
                {
                    if (seq.Count == 1) return new List<int>() { i };
                    return seq;
                }
                seq.Add(i);
                return seq;
            }).ToArray();
    }
}