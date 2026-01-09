using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Trees
{
    [DebuggerDisplay("{Value}")]
    public class Node
    {
        public readonly int Value;
        public List<Node> Nodes = new List<Node>();

        public Node(int value)
        {            
            Value = value;
        }

        public static Node GetSampleTree()
        {
            var root = new Node(1);
            var node2 = new Node(2);
            var node3 = new Node(3);
            root.Nodes.Add(node2);
            root.Nodes.Add(node3);
            var node4 = new Node(4);
            var node5 = new Node(5);
            var node6 = new Node(6);
            node2.Nodes.Add(node4);
            node2.Nodes.Add(node5);
            node2.Nodes.Add(node6);
            var node7 = new Node(7);
            var node8 = new Node(8);
            node3.Nodes.Add(node7);
            node3.Nodes.Add(node8);
            return root;
        }

        public string TraverseBreadthFirst()
        {
            var output = "";
            TraverseBreadthFirst(n => output += n.Value + " ");
            return output;
        }

        public string TraverseDepthFirst()
        {
            var output = "";
            TraverseDepthFirst(n => output += n.Value + " ");
            return output;
        }

        public void TraverseBreadthFirst(System.Action<Node> action)
        {
            var queue = new Queue<Node>();
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                action(current);
                foreach (var child in current.Nodes) queue.Enqueue(child);
            }
        }

        public void TraverseDepthFirst(System.Action<Node> action)
        {
            var stack = new Stack<Node>();
            stack.Push(this);
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                action(current);                
                foreach (var child in current.Nodes) stack.Push(child);
                // Push children in reverse order to maintain left-to-right traversal
                // for (int i = current.Nodes.Count - 1; i >= 0; i--) stack.Push(current.Nodes[i]);
            }
        }
    }
}
