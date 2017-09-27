using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTrees
{
    /// <summary> A node of a tree (may be a sub-tree) </summary>
    public class Node
    {
        public readonly int value;
        public Node left;
        public Node right;

        public Node(int value, Node left = null, Node right = null)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }

        public bool IsLeaf
        {
            get
            {
                return this.left == null && this.right == null;
            }
        }

        public bool HasLeft
        {
            get { return this.left != null; }
        }

        public bool HasRight
        {
            get { return this.right != null; }
        }

        #region Util

        public override string ToString()
        {
            return this.value.ToString();
        }

        public static string NodeListToString(List<Node> nodes)
        {
            return string.Join(" ", (from n in nodes select n.value).ToList());
        }

        #endregion
    }
}
