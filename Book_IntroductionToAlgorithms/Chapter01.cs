using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Book_IntroductionToAlgorithms
{
    [TestClass]
    public class Chapter01
    {
        // Exercise 1.1-1
        // Give a real-world example that requires sorting or a real-world example that requires computing a convex hull.
        // - Sorting: Sort a list of airplane tickets by price ascending
        // - Convex hull: Face recogntition algorithms

        // Exercise 1.1-2
        // Other than speed, what other measures of efficiency might one use in a real-world setting?
        // - Space. How much space an algorithms requires to work

        // Exercise 1.1-3
        // Select a data structure that you have seen previously, and discuss its strengths and limitations.
        // - Array: Fast but its length cannot be changed once it has been initialized

        // Exercise 1.1-4
        // How are the shortest-path and traveling-salesman problems given above similar? How are they different?
        // - In both problems we have to find the shortest distance between points
        //   But in shortest path we have 2 points whereas in the traveling-salesman we have N>=2 points

        // Exercise 1.1-5
        // Come up with a real-world problem in which only the best solution will do. 
        // Then come up with one in which a solution that is “approximately” the best is good enough.
        // - Find the exit from a labyrinth (assuming the labyrinth has only one exit)
        // - Find a route from point a to point b on a map

        /// <summary> Exercise 1.2-2 </summary>
        [TestMethod]
        public void Exercise_1_2_2()
        {
            // Suppose we are comparing implementations of insertion sort and merge sort on the
            // same machine. For inputs of size n, insertion sort runs in 8n^2 steps, while merge
            // sort runs in 64n lg n steps. For which values of n does insertion sort beat merge
            // sort?
            int n = 2;
            while (true)
            {
                double insertionSortTime = 8 * n * n;
                double mergeSortTime = 64*n*System.Math.Log(n, 2);
                if (mergeSortTime < insertionSortTime) break;
                n++;
            }

            Assert.AreEqual(44, n);
        }

        /// <summary> Exercise 1.2-3 </summary>
        [TestMethod]
        public void Exercise_1_2_3()
        {
            // What is the smallest value of n such that an algorithm whose running time is 100n^2
            // runs faster than an algorithm whose running time is 2^n on the same machine?
            int n = 1;
            while (true)
            {
                double squaredAlg = 100 * n * n;
                double expAlg = System.Math.Pow(2, n);

                // for small values of n the exp algorithm is faster
                // but eventually it becomes slower
                if (expAlg > squaredAlg) break; 
                n++;
            }

            // Up until n = 15 the exponential time algorithm is faster
            Assert.AreEqual(15, n);
        }

        [TestMethod]
        public void Problem_1_1_Comparison_of_running_times()
        {
            // For each function f n and time t in the following table, determine the largest
            // size n of a problem that can be solved in time t, assuming that the algorithm to
            // solve the problem takes f n microseconds.

            // 1 sec     = 1 000 000 μs                                = 1e6      μs
            // 1 min     = 1 000 000 * 60 μs                           = 6e7      μs
            // 1 hour    = 1 000 000 * 60 * 60 μs                      = 36e8     μs
            // 1 day     = 1 000 000 * 60 * 60 * 24 μs                 = 864e8    μs      NOTE: assume that it is not the daylight change day
            // 1 month   = 1 000 000 * 60 * 60 * 24 * 30 μs            = 2592e9   μs      NOTE: assume that 1 month = 30 days, although this is not always true
            // 1 year    = 1 000 000 * 60 * 60 * 24 * 30 * 12 μs       = 31104e9  μs      a year always has 12 months (a year not always has 365 days but the above assumption swallowed this)
            // 1 century = 1 000 000 * 60 * 60 * 24 * 30 * 12 * 100 μs = 31104e11 μs   

        
            // =================== lg(n) ======================
            // for size n the algorithm takes time t = lg(n) => n = 2^t
            // 1 sec     -> n = 2^1e6
            // 1 min     -> n = 2^6e7
            // 1 hour    -> n = 2^36e8
            // 1 day     -> n = 2^864e8
            // 1 month   -> n = 2^2592e9
            // 1 year    -> n = 2^31104e9
            // 1 century -> n = 2^31104e11

            // =================== sqrt(n) ======================
            // for size n the algorithm takes time t = sqrt(n) -> n = t^2
            // 1 sec     -> n = 1e6^2 = 1e12
            // 1 min     -> n = 6e7^2 = 36e14
            // 1 hour    -> n = 36e8^2 = 1296e16
            // 1 day     -> n = 864e8^2 = 746496e16
            // 1 month   -> n = 2592e9^2 = 6718464e18
            // 1 year    -> n = 31104e9^2 = 967458816e18
            // 1 century -> n = 2^31104e11 = 967458816e22

            // =================== n ======================
            // for size n the algorithm takes time t = n
            // 1 sec     -> n = 1e6
            // 1 min     -> n = 6e7
            // 1 hour    -> n = 36e8
            // 1 day     -> n = 864e8
            // 1 month   -> n = 2592e9
            // 1 year    -> n = 31104e9
            // 1 century -> n = 31104e11

            // =================== n*lg(n) ======================
            // for size n the algorithm takes time t = n * lg(n) -> t/n = lg(n) -> 2^(t/n) = n -> (2^t)^(1/n) = n -> 2^t = n^n
            // Can't easily solve for n. Try to approximate

            // 1 sec     -> n = 1e6
            var max_n_1_sec = GetMaxNFor_nlgn(1e6);    // 62748

            // 1 min     -> n = 6e7
            var max_n_1_min = GetMaxNFor_nlgn(6e7);    // 2801419
            
            // 1 hour    -> n = 36e8, 36e8 is too big for the above function. Approximate.
            var max_n_1_hour = Math.Convergence.Converge(36e8, (long)1e4); // 133378058

            // 1 day     -> n = 864e8
            var max_n_1_day = Math.Convergence.Converge(864e8, (long)1e6); // 2755147513

            // 1 month   -> n = 2592e9
            var max_n_1_month = Math.Convergence.Converge(2592e9, (long)1e9); // 71870856404

            // 1 year    -> n = 31104e9
            var max_n_1_year = Math.Convergence.Converge(31104e9, (long)1e9); // 787089606198

            // 1 century -> n = 31104e11
            var max_n_1_century = Math.Convergence.Converge(31104e11, (long)1e12); // 67699498463641

            // =================== n^2 ======================
            // for size n the algorithm takes time t = n^2 -> n = sqrt(t)
            // 1 sec     -> t = sqrt(1e6) = 1000
            // 1 min     -> t = sqrt(6e7) = 7745.96669241
            // 1 hour    -> t = sqrt(36e8) = 60000
            // 1 day     -> t = sqrt(864e8) = 293938.769134
            // 1 month   -> t = sqrt(2592e9) = 1609968.9438
            // 1 year    -> t = sqrt(31104e9) = 5577096.01854
            // 1 century -> t = sqrt(31104e11) = 55770960.1854

            // =================== n^3 ======================
            // for size n the algorithm takes time t = n^3 -> n = cubic_root(t)
            // 1 sec     -> t = cubic_root(1e6) = 100
            // 1 min     -> t = cubic_root(6e7) = 391.486764
            // 1 hour    -> t = cubic_root(36e8) = 1532.6188647871062131972510568659
            // 1 day     -> t = cubic_root(864e8) = 4420.8377983684639269357874002958
            // 1 month   -> t = cubic_root(2592e9) = 13736.570910639982413696506543276
            // 1 year    -> t = cubic_root(31104e9) = 31448.896730506759285699935365304
            // 1 century -> t = cubic_root(31104e11) = 145972.84789376160443756267994571

            // =================== 2^n ======================
            // for size n the algorithm takes time t = 2^n -> n = lg(t)
            // 1 sec     -> t = lg(1e6) = 19.9315685693
            // 1 min     -> t = lg(6e7) = 25.8384591649
            // 1 hour    -> t = lg(36e8) = 31.7453497605
            // 1 day     -> t = lg(864e8) = 36.3303122613
            // 1 month   -> t = lg(2592e9) = 41.2372028569
            // 1 year    -> t = lg(31104e9) = 44.8221653576
            // 1 century -> t = lg(31104e11) = 51.4660215474

            // =================== 2^n ======================
            // for size n the algorithm takes time t = n! 
            // Can't solve for n

            // 1 sec     -> n = 1e6
            Assert.AreEqual(10, GetMaxNForNFactorial(1e6));

            // 1 min     -> n = 6e7
            Assert.AreEqual(12, GetMaxNForNFactorial(6e7));

            // 1 hour    -> n = 36e8, 36e8 is too big for the above function. Approximate.
            Assert.AreEqual(13, GetMaxNForNFactorial(36e8));

            // 1 day     -> n = 864e8
            Assert.AreEqual(14, GetMaxNForNFactorial(864e8));

            // 1 month   -> n = 2592e9
            Assert.AreEqual(16, GetMaxNForNFactorial(2592e9));

            // 1 year    -> n = 31104e9
            Assert.AreEqual(17, GetMaxNForNFactorial(31104e9));

            // 1 century -> n = 31104e11
            Assert.AreEqual(18, GetMaxNForNFactorial(31104e11));
        }

        /// <summary>
        /// Slow if maxTime > 1e8
        /// </summary>
        /// <param name="maxTime"></param>
        /// <returns></returns>
        private static long GetMaxNFor_nlgn(double maxTime)
        {
            long n = 1;
            double time = 0;
            while (time <= maxTime)
            {
                time = n * System.Math.Log(n, 2);
                n++;
            }
            return n;
        }

        private static int GetMaxNForNFactorial(double maxTime)
        {
            int n = 1;
            while (true)
            {
                var factorial = Math.Factorial.Calculate(n);
                if (factorial > maxTime) break;
                n++;
            }
            return n;
        }
    }
}