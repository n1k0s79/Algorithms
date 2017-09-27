using System.Collections.Generic;

namespace BinaryTrees
{
    public class SizeFinder
    {
        /// <summary> Recursively finds the size of the tree having [node] as its root. </summary>
        /// <remarks>The number of all ancestors of a node equals the number of nodes of the left subtree 
        /// plus the number of nodes of the right subtree plus one (for this node)</remarks>
        public static int FindSizeR(Node node)
        {
            return node == null ? 0 : FindSizeR(node.left) + FindSizeR(node.right) + 1;
        }

        /// <summary> Iteratively finds the size of the tree having [node] as its root. </summary>
        /// <remarks>
        /// Push the root node on a stack
        /// While the stack has nodes
        ///     pop a node and increment the counter
        ///     Push the node's children on the stack
        /// Return the counter
        /// </remarks>
        public static int FindSizeI(Node node)
        {
            if (node == null) return 0;
            var s = new Stack<Node>();
            s.Push(node);
            int size = 0;

            while (s.Count > 0)
            {
                Node n = s.Pop();
                size ++;
                if (n.HasLeft) s.Push(n.left);
                if (n.HasRight) s.Push(n.right);
            }

            return size;
        }
    }
}