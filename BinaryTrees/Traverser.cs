using System;
using System.Collections.Generic;

namespace BinaryTrees
{
    public class Traverser
    {
        /// <summary> Traverses the tree recursively </summary>
        public static void TraversePreorder(Node node, Action<Node> action)
        {
            if (node == null) return;

            // preorder: the root node preceeds left and right
            action(node);

            TraversePreorder(node.left, action);

            TraversePreorder(node.right, action);
        }

        /// <summary> Traverses the tree iteratively </summary>
        public static void TraversePreorderI(Node node, Action<Node> action)
        {
            var s = new Stack<Node>();
            if (node != null) s.Push(node);
            while (s.Count > 0)
            {
                var n = s.Pop();
                action(n);
                if (n.HasRight) s.Push(n.right);
                if (n.HasLeft) s.Push(n.left);
            }
        }

        /// <summary> Starting from this node traverses the tree inorder </summary>
        public static void TraverseInorder(Node node, Action<Node> action)
        {
            if (node == null) return;

            TraverseInorder(node.left, action);

            // inorder: the root node is inside left and right
            action(node);

            TraverseInorder(node.right, action);
        }

        public static void TraversePostorder(Node node, Action<Node> action)
        {
            if (node == null) return;

            TraversePostorder(node.left, action);

            TraversePostorder(node.right, action);

            // postorder: the root node comes after left and right
            action(node);
        }
    }
}
