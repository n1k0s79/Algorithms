namespace BinaryTrees
{
    public class Generator
    {
        /// <summary>
        /// [github Folder]Algorithms\BinaryTrees\smalltree.gif
        /// </summary>
        public static Node SmallTree
        {
            get
            {
                Node n4 = new Node(4);
                Node n5 = new Node(5);
                Node n2 = new Node(2, n4, n5);
                Node n3 = new Node(3);
                Node n1 = new Node(1, n2, n3);
                return n1;
            }
        }

        public static Node SmallTree2
        {
            get
            {
                Node n6 = new Node(6);
                Node n4 = new Node(4);
                Node n5 = new Node(5, n6);
                Node n2 = new Node(2, n4, n5);
                Node n3 = new Node(3);
                Node n1 = new Node(1, n2, n3);
                return n1;
            }
        }

        /// <summary> Same as small tree but constructed in a different way </summary>
        public static Node Tree1
        {
            get
            {
                Node root = new Node(1);
                root.left = new Node(2);
                root.right = new Node(3);
                root.left.left = new Node(4);
                root.left.right = new Node(5);
                return root;
            }
        }

        public static Node ListTree
        {
            get
            {
                var ret = new Node(1);
                
                var parent = ret;
                for (int i = 2; i < 10; i++)
                {
                    var n = new Node(i);
                    parent.left = n;
                    parent = n;
                }

                return ret;
            }
        }
    }
}