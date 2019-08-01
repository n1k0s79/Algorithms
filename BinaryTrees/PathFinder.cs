using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTrees
{
    public class PathFinder
    {
        public static List<List<Node>> GetAllPaths(Node node)
        {
            List<List<Node>> paths = new List<List<Node>>();
            GetPaths(node, new List<Node>(), x => paths.Add(x));
            return paths;
        }

        /// <summary> Finds all tree paths recursively </summary>
        /// <param name="node"> The starting node</param>
        /// <param name="path"> The path so far as it has resulted from the recursions. </param>
        /// <param name="pathDiscovered"> Fired every time a path is discovered. </param>
        /// <remarks>Strategy:
        /// Does the node have children?
        /// Get the paths that result from visiting the children.
        /// If not then it is a leaf node. A path has been found.
        /// </remarks>
        private static void GetPaths(Node node, List<Node> path, Action<List<Node>> pathDiscovered)
        {
            if (node == null) return;

            path.Add(node);

            if (node.IsLeaf)
            {
                pathDiscovered(path);
            }
            else
            {
                GetPaths(node.left, new List<Node>(path), pathDiscovered); // note that I create a new list
                GetPaths(node.right, new List<Node>(path), pathDiscovered);
                    // this way I use the call stack to save the current state of the path
                    // If I didn't then do that and passed the list as a reference, the algorithm would not work
            }
        }

        private static void GetMaxDistinct(Node node)
        {
            if (node == null) return;

            //path.Add(node);

            //if (node.IsLeaf)
            //{
            //    pathDiscovered(path);
            //}
            //else
            //{
            //    GetPaths(node.left, new List<Node>(path), pathDiscovered); // note that I create a new list
            //    GetPaths(node.right, new List<Node>(path), pathDiscovered);
            //    // this way I use the call stack to save the current state of the path
            //    // If I didn't then do that and passed the list as a reference, the algorithm would not work
            //}
        }

        /// <summary> Finds all tree paths iteratively </summary>
        public static List<List<Node>> GetPathsI(Node node)
        {
            var ret = new List<List<Node>>();
            if (node == null) return ret;

            var stack = new Stack<List<Node>>();
            stack.Push(new List<Node> {node});

            int iterations = 0;
            while (stack.Count > 0)
            {
                iterations++;
                var path = stack.Pop();
                var lastPathNode = path[path.Count - 1];

                if (lastPathNode.IsLeaf)
                    ret.Add(path);
                else
                {
                    if (lastPathNode.HasRight) stack.Push(new List<Node>(path.ToArray()) {lastPathNode.right});
                    if (lastPathNode.HasLeft) stack.Push(new List<Node>(path.ToArray()) {lastPathNode.left});
                }
            }

            return ret;
        }

        /// <summary>
        /// Given a tree and a sum, return true if there is a path from the root
        /// down to a leaf, such that adding up all the values along the path
        /// equals the given sum.
        /// </summary>
        ///<remarks>
        /// Strategy: subtract the node value from the sum when recurring down,
        /// and check to see if the sum is 0 when you run out of tree.
        /// </remarks>
        public static bool HasPathWithSum(Node node, int sum)
        {
            // If node is null then we were on a leaf node. 
            // If it also so happens that sum = 0 then I reached my objective
            if (node == null) return (sum == 0);

            else
            {
                bool ret = false;

                // otherwise check both subtrees
                int subSum = sum - node.value;

                // If we reach a leaf node and sum becomes 0 then return true
                if (subSum == 0 && node.left == null && node.right == null) return true;

                if (node.left != null) ret = HasPathWithSum(node.left, subSum);
                if (node.right != null) ret = ret || HasPathWithSum(node.right, subSum);

                return ret;
            }
        }

        /// <summary> Return the sum of all paths </summary>
        public static int GetPathSums(Node node, List<Node> path, int sum)
        {
            if (node == null) return sum;

            path.Add(node);
            sum += node.value;

            if (node.IsLeaf)
            {
                int a = sum;
            }
            else
            {
                GetPathSums(node.left, new List<Node>(path), sum); // note that I create a new list
                GetPathSums(node.right, new List<Node>(path), sum);
                // this way I use the call stack to save the current state of the path
                // If I didn't then do that and passed the list as a reference, the algorithm would not work
            }

            return sum;
        }

        public static long GetPathSum(List<Node> path)
        {
            return path.Aggregate((long)0, (current, oldNode) => current + (long)oldNode.value);
        }
    }
}