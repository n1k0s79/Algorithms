using System;
using System.Collections.Generic;

namespace BinaryTrees
{
    public class ZigZagCounter
    {
        public static int GetMaxZigZags(Node node)
        {
            int ret = 0;
            var stack = new Stack<Path>();
            stack.Push(new Path(node));

            int iterations = 0;

            while (stack.Count > 0)
            {
                iterations++;
                var path = stack.Pop();

                if (path.LastNode.IsLeaf)
                {
                    if (path.zigZags > ret) ret = path.zigZags;
                }
                else
                {
                    if (path.LastNode.HasRight)
                    {
                        var pathr = new Path(path);
                        pathr.Add(path.LastNode.right);
                        stack.Push(pathr);
                    }

                    if (path.LastNode.HasLeft)
                    {
                        var pathl = new Path(path);
                        pathl.Add(path.LastNode.left);
                        stack.Push(pathl);
                    }
                }
            }

            return ret;
        }

        enum Turns
        {
            Left, 
            Right
        }

        class Path
        {
            public List<Node> nodes;
            public int zigZags = 0;
            public Turns? lastTurn;

            public Path(List<Node> nodes)
            {
                this.nodes = new List<Node>(nodes.ToArray());
            }

            public Path(Node node)
            {
                this.nodes = new List<Node> {node};
            }

            public Path(Path p)
            {
                this.nodes = new List<Node>(p.nodes.ToArray());
                this.lastTurn = p.lastTurn;
                this.zigZags = p.zigZags;
            }

            public void Add(Node node)
            {
                if (LastNode != null)
                {
                    Turns turn = Turns.Right;
                    if (LastNode.left.Equals(node)) turn = Turns.Left;
                    if (lastTurn.HasValue && turn != lastTurn) this.zigZags++;
                    this.lastTurn = turn;
                }

                this.nodes.Add(node);
            }

            public Node LastNode
            {
                get
                {
                    if (this.nodes.Count == 0) return null;
                    return this.nodes[this.nodes.Count - 1];
                }
            }

            public override string ToString()
            {
                return string.Join(" ", this.nodes.ConvertAll(x => x.ToString()));
            }
        }


        /// <summary>  Test this... </summary>
        public static int FindZigZags(Node node)
        {
            // TODO: And understand WHY it works...
            return FindZigZag(node, 0) - 1;
        }

        private static int fi = 0;
        private static int FindZigZag(Node node, int max)
        {
            fi++;
            if (node == null) return 0;

            int lh = Count(node, true, 0);
            int rh = Count(node, false, 0);

            max = Math.Max(lh, rh);
            max = Math.Max(max, FindZigZag(node.left, max));
            max = Math.Max(max, FindZigZag(node.right, max));

            return max;
        }

        private static int Count(Node node, bool moveLeft, int count)
        {
            if (node == null) return count;

            count = moveLeft
                ? Count(node.left, !moveLeft, node.left == null ? count : count + 1)
                : Count(node.right, !moveLeft, node.right == null ? count : count + 1);

            return count;
        }         
    }
}