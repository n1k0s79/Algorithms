using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryTrees
{
    namespace BinaryTrees
    {
        [TestClass]
        public class Tests
        {
            [TestMethod]
            public void TestSizeR()
            {
                int size = SizeFinder.FindSizeR(Generator.SmallTree);
                Assert.AreEqual(5, size);
            }

            [TestMethod]
            public void TestSizeI()
            {
                int size = SizeFinder.FindSizeI(Generator.SmallTree);
                Assert.AreEqual(5, size);
            }

            [TestMethod]
            public void TestHeightR()
            {
                int height = HeightFinder.FindHeightR(Generator.SmallTree);
                Assert.AreEqual(2, height);
            }

            [TestMethod]
            public void TestHeightI()
            {
                Assert.AreEqual(2, HeightFinder.FindHeightI(Generator.SmallTree));
                Assert.AreEqual(3, HeightFinder.FindHeightI(Generator.SmallTree2));
            }

            [TestMethod]
            public void HeightIterativelyForListTree()
            {
                Assert.AreEqual(8, HeightFinder.FindHeightI(Generator.ListTree));
            }

            [TestMethod]
            public void TestHeightSingleNode()
            {
                var node = new Node(0);
                int height = HeightFinder.FindHeightR(node);
                Assert.AreEqual(0, height);
            }

            [TestMethod]
            public void TestTraversalInorder()
            {
                var traversedNodes = new List<Node>();
                Traverser.TraverseInorder(Generator.SmallTree, x => traversedNodes.Add(x));
                Assert.AreEqual("4 2 5 1 3", Node.NodeListToString(traversedNodes));
            }

            [TestMethod]
            public void TestTraversalPostorder()
            {
                var traversedNodes = new List<Node>();
                Traverser.TraversePostorder(Generator.SmallTree, x => traversedNodes.Add(x));
                Assert.AreEqual("4 5 2 3 1", Node.NodeListToString(traversedNodes));
            }

            [TestMethod]
            public void TestTraversalPreorderR()
            {
                var traversedNodes = new List<Node>();
                Traverser.TraversePreorder(Generator.SmallTree, x => traversedNodes.Add(x));
                Assert.AreEqual("1 2 4 5 3", Node.NodeListToString(traversedNodes));
            }

            [TestMethod]
            public void TestTraversalPreorderI()
            {
                var traversedNodes = new List<Node>();
                Traverser.TraversePreorderI(Generator.SmallTree, x => traversedNodes.Add(x));
                Assert.AreEqual("1 2 4 5 3", Node.NodeListToString(traversedNodes));
            }

            [TestMethod]
            public void TestPaths()
            {
                var smallTreeRootNode = Generator.SmallTree;
                var paths = PathFinder.GetAllPaths(smallTreeRootNode);
                Assert.AreEqual(3, paths.Count);
                Assert.AreEqual("1 2 4", Node.NodeListToString(paths[0]));
                Assert.AreEqual("1 2 5", Node.NodeListToString(paths[1]));
                Assert.AreEqual("1 3", Node.NodeListToString(paths[2]));
            }

            [TestMethod]
            public void TestPathsI()
            {
                var paths = PathFinder.GetPathsI(Generator.SmallTree);
                Assert.AreEqual("1 2 4", Node.NodeListToString(paths[0]));
                Assert.AreEqual("1 2 5", Node.NodeListToString(paths[1]));
                Assert.AreEqual("1 3", Node.NodeListToString(paths[2]));
            }

            [TestMethod]
            public void TestZigZags()
            {
                ZigZagCounter.FindZigZags(Generator.SmallTree);
                Assert.AreEqual(1, ZigZagCounter.GetMaxZigZags(Generator.SmallTree));
                Assert.AreEqual(0, ZigZagCounter.GetMaxZigZags(Generator.ListTree));
            }

            [TestMethod]
            public void TestPathSum()
            {
                var ret = PathFinder.HasPathWithSum(Generator.SmallTree, 8);
           }

            [TestMethod]
            public void TestMaxPathSum()
            {
                var ret = PathFinder.GetPathSums(Generator.SmallTree, new List<Node>(), 0);
            }

            [TestMethod]
            public void FinSum()
            {
                Assert.AreEqual(15, SumFinder.GetNodesSum(Generator.SmallTree));
            }

            [TestMethod]
            public void TestDeserialize()
            {
                //    3
                //   7 4
                //  2 4 6
                // 8 5 9 3
                var s = "3\n7 4\n2 4 6\n8 5 9 3";
                var node = Deserializer.FromPyramidWithDuplicates(s);
                Assert.AreEqual(3, node.value);

                Assert.AreEqual(7, node.left.value);
                Assert.AreEqual(4, node.right.value);

                Assert.AreEqual(2, node.left.left.value);
                Assert.AreEqual(4, node.left.right.value);
                Assert.AreEqual(6, node.right.right.value);

                Assert.AreEqual(8, node.left.left.left.value);
                Assert.AreEqual(5, node.left.left.right.value);
                Assert.AreEqual(9, node.right.right.left.value);
                Assert.AreEqual(3, node.right.right.right.value);
            }
        }
    }
}
