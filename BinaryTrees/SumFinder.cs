namespace BinaryTrees
{
    public class SumFinder
    {
        public static int GetNodesSum(Node node)
        {
            if (node == null) return 0;
            return node.value + GetNodesSum(node.left) + GetNodesSum(node.right);
        }
    }
}