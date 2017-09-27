using System;
using System.Collections.Generic;

namespace BinaryTrees
{
    public class HeightFinder
    {
        /// <summary> Finds the height of the tree recursively </summary>
        public static int FindHeightR(Node node)
        {
            if (node == null) return -1;
            int leftHeight = FindHeightR(node.left);
            int rightHeight = FindHeightR(node.right);
            return Math.Max(leftHeight, rightHeight) + 1;
        }

        /// <summary> Finds the height of the tree iteratively </summary>
        public static int FindHeightI(Node node)
        {
            int height = 0;
            var s = new Stack<Node>();
            s.Push(node);

            while (s.Count > 0)
            {
                var n = s.Pop();
                if (n.HasLeft || n.HasRight) height ++;
                if (n.HasLeft) s.Push(n.left);
                if (n.HasRight) s.Push(n.right);
            }

            return height;
        }
    }
}