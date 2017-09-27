using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codility
{
    [TestClass]
    public class MaxCounters
    {   
        public static int[] solution(int N, int[] A)
        {
            var counters = new int[N];
            int maxCounter = 0;
            foreach(var op in A)
            {
                if (op <= N)
                {
                    counters[op - 1]++;
                    if (counters[op - 1] > maxCounter) maxCounter = counters[op - 1];
                }
                if (op == N + 1)
                {
                    counters = Enumerable.Repeat(maxCounter, N).ToArray();
                }
            }

            return counters;
        }

        // Observe that the Max event is like an extinction event
        // There's no point in keeping count the details of what came before the "extinction event"
        // Only the max counter
        // This solution got 66% in codility. Why? It had 100% correctness but it timed out in the last 3 test cases.
        // Perhaps because of the dictionary...
        public static int[] solution_opt(int N, int[] A)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 1; i <= N; i++) dict[i] = 0;

            int maxCounter = 0;
            int lastMaxEvent = 0;
            int maxCounterArLastMaxEvent = 0;
            for (int i = 0; i < A.Length; i++)
            {
                var op = A[i];
                if (op <= N && op > 0)
                {
                    dict[op]++; // keep track of how many times a counter was incremented
                    if (dict[op] > maxCounter) maxCounter = dict[op];
                }
                else if (op == N + 1)
                {
                    lastMaxEvent = i;                           // max event. Store the "time" it occured.
                    maxCounterArLastMaxEvent = maxCounter;      // Store the value of the max counter
                }
            }
            
            var counters = Enumerable.Repeat(maxCounterArLastMaxEvent, N).ToArray();
            if (lastMaxEvent == 0)
            {
                foreach (var kvp in dict) counters[kvp.Key - 1] = kvp.Value;
            }
            else
            {
                for (int i = lastMaxEvent + 1; i < A.Length; i++) counters[A[i] - 1]++;
            }            

            return counters;
        }

        public static int[] solution_opt2(int N, int[] A)
        {
            // Strategy:
            // After executing all operations each counter will have:
            // The value it was assigned after all the increments on it
            // OR
            // The value of the Max counter at the last max event
            // whatever is greater

            var counters = new int[N];
            int currentMax = 0;
            int lastMax = 0;

            for (int i= 0; i < A.Length; i++)
            {
                var op = A[i] -1;   // 1-based indexing

                if (op == N)        // max-out event
                {
                    lastMax = currentMax;
                }
                else
                {
                    counters[op] = Math.Max(counters[op], lastMax) + 1;
                    currentMax = Math.Max(currentMax, counters[op]);
                }
            }
        
            for(int i = 1; i<=N; i++)
            {
                counters[i-1] = Math.Max(counters[i-1], lastMax);
            }

            return counters;
        }


        [TestMethod]
        public void TestSolution()
        {
            var A = new int[] { 3, 4, 4, 6, 1, 4, 4 };
            var ret = solution_opt2(5, A);
            Arrays.Generator.Generate(100, 1, 5);
        }

        [TestMethod]
        public void TestSingle()
        {
            var A = Arrays.Generator.Generate(5, 1, 1);
            var ret2 = solution_opt(1, A);
        }

        [TestMethod]
        public void Tests()
        {
            for(int N = 1; N <100000; N++)
            {
                var A = Arrays.Generator.Generate(100000, 1, N+1);
                var maxCounters = A.Count(x => x == N);
                var ret = solution(N, A);
                var ret2 = solution_opt(N, A);
                var ret3 = solution_opt2(N, A);
                Assert.AreEqual(Arrays.Util.ArrayToString(ret), Arrays.Util.ArrayToString(ret2));
                Assert.AreEqual(Arrays.Util.ArrayToString(ret), Arrays.Util.ArrayToString(ret3));
            }                       
        }

        [TestMethod]
        public void TestLarge()
        {
            //var A = Arrays.Generator.Generate(100000, 1, 1);
            //var maxCounters = A.Count(x => x == N);
            //var ret = solution(N, A);
            //var ret2 = solution_opt(N, A);
            //Assert.AreEqual(Arrays.Util.ArrayToString(ret), Arrays.Util.ArrayToString(ret2));
        }
    }
}