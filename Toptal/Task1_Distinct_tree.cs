using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toptal.Task1
{
    [TestClass]
    public class Solution
    {
        [TestMethod]
        public void TestThis()
        {
            var s = new Solution();
            s.solution(Solution.SmallTree);
        }

        public int solution(Tree T)
        {
            int maxCount = 0;
            var paths = GetAllPaths(T);
            foreach (var p in paths)
            {
                int d = GetDistinctValues(p);
                if (d > maxCount) maxCount = d;
            }

            return maxCount;
        }

        /// <summary>
        /// [github Folder]Algorithms\BinaryTrees\smalltree.gif
        /// </summary>
        public static Tree SmallTree
        {
            get
            {
                Tree n4 = new Tree(4);
                Tree n5 = new Tree(5);
                Tree n2 = new Tree(2, n4, n5);
                Tree n3 = new Tree(3);
                Tree n1 = new Tree(1, n2, n3);
                return n1;
            }
        }
        private int GetDistinctValues(List<Tree> path)
        {
            var values = new List<int>();
            foreach (var n in path) values.Add(n.x);
            return values.Distinct().Count();
        }

        public static List<List<Tree>> GetAllPaths(Tree node)
        {
            List<List<Tree>> paths = new List<List<Tree>>();
            GetPaths(node, new List<Tree>(), x => paths.Add(x));
            return paths;
        }

        //public static int GetMaxDistinctPath(Tree node)
        //{
        //    List<List<Tree>> paths = new List<List<Tree>>();
        //    GetPaths(node, new List<Tree>(), x => paths.Add(x));
        //    return paths;
        //}

        private static void GetPathsRec(Tree node, int[] path, int pathLen, Action<int[], int> pathDiscovered)
        {
            if (node == null) return;

            path[pathLen] = node.x;
            pathLen++;

            if (node.IsLeaf) 
            {
                pathDiscovered(path, pathLen);
            }
            else
            {
                GetPathsRec(node.l, path, pathLen, pathDiscovered);
                GetPathsRec(node.r, path, pathLen, pathDiscovered);
            }    
        }

        private static void GetPaths(Tree node, List<Tree> path, Action<List<Tree>> pathDiscovered)
        {
            if (node == null) return;

            path.Add(node);

            if (node.IsLeaf)
            {
                pathDiscovered(path);
            }
            else
            {
                GetPaths(node.l, new List<Tree>(path), pathDiscovered);
                GetPaths(node.r, new List<Tree>(path), pathDiscovered);
            }
        }

        public class Tree
        {
            public int x;
            public Tree l;
            public Tree r;

            public Tree(int value, Tree left = null, Tree right = null)
            {
                this.x = value;
                this.l = left;
                this.r = right;
            }

            public bool IsLeaf
            {
                get
                {
                    return this.l == null && this.r == null;
                }
            }

            public bool HasLeft
            {
                get { return this.l != null; }
            }

            public bool HasRight
            {
                get { return this.r != null; }
            }
        }
    }
}
