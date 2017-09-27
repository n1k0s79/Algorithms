using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Euler
{  
    [TestClass]
    public class Problem018_Maximum_path_sum_I
    {
        [TestMethod]
        public void SmallTriangle_MySolution()
        {
            // my strategy was to construct a binary tree from the input
            // find all paths and then find the path with the greatest sum
            // this solution had the following disadvantages:
            // 1) lots of code (I had it already though)
            // 2) duplicate nodes (although the result was correct)
            var b = BinaryTrees.Deserializer.FromPyramidWithDuplicates(SmallTriangle);
            var paths = BinaryTrees.PathFinder.GetAllPaths(b);
            var max = paths.Max(x => BinaryTrees.PathFinder.GetPathSum(x));
            Assert.AreEqual(23, max);
        }
        [TestMethod]
        public void TestSolution()
        {                           
            var b = BinaryTrees.Deserializer.FromPyramidWithDuplicates(LargeTriangle);
            var time = Util.GetExecutionTime(() => // 42ms
            {
                var paths = BinaryTrees.PathFinder.GetAllPaths(b);
                Assert.AreEqual(16384, paths.Count);
                Assert.AreEqual(1074, paths.Max(x => BinaryTrees.PathFinder.GetPathSum(x)));
            });

            // optimized solution
            var time2 = Util.GetExecutionTime(() => // 1ms
            {
              Assert.AreEqual(1074, MaxBottomUp(LargeTriangle));
            });
        }

        private static string SmallTriangle
        {
            get
            {
                return "3\n" +
                        "7 4\n" +
                        "2 4 6\n" +
                        "8 5 9 3\n";
            }
        }

        private static string LargeTriangle
        {
            get
            {
                return "75\n" +
                        "95 64\n" +
                        "17 47 82\n" +
                        "18 35 87 10\n" +
                        "20 04 82 47 65\n" +
                        "19 01 23 75 03 34\n" +
                        "88 02 77 73 07 63 67\n" +
                        "99 65 04 28 06 16 70 92\n" +
                        "41 41 26 56 83 40 80 70 33\n" +
                        "41 48 72 33 47 32 37 16 94 29\n" +
                        "53 71 44 65 25 43 91 52 97 51 14\n" +
                        "70 11 33 28 77 73 17 78 39 68 17 57\n" +
                        "91 71 52 38 17 14 91 43 58 50 27 29 48\n" +
                        "63 66 04 68 89 53 67 30 73 16 69 87 40 31\n" +
                        "04 62 98 27 23 09 70 98 73 93 38 53 60 04 23\n";
            }
        }

        private static int[][] TriangleToList(string triangle)
        {            
            var lines = triangle.Split('\n');
            var ret = new int[lines.Length - 1][];
            for(int i = 0; i<ret.Length; i++)
            {
                ret[i] = System.Array.ConvertAll(lines[i].Split(' '), System.Int32.Parse);
            }

            return ret;
        }

        private static int MaxBottomUp(string tri)
        {
            var triangle = TriangleToList(tri);
            for (int i = triangle.Length - 2; i >= 0; i--)
            {
                for (int j = 0; j < triangle[i].Length; j++)
                {
                    var downLeft = triangle[i + 1][j];
                    var downRight = triangle[i + 1][j + 1];
                    triangle[i][j] += System.Math.Max(downLeft, downRight);
                }
            }

            return triangle[0][0];
        }
    }
}