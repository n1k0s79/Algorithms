using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trees;

namespace BinaryTrees
{
    namespace BinaryTrees
    {
        [TestClass]
        public class Tests
        {
            [TestMethod]
            public void Test1()
            {
                var m = Node.GetSampleTree();
                var resultBfs = m.TraverseBreadthFirst();
                Assert.AreEqual("1 2 3 4 5 6 7 8 ", resultBfs);
                var resultDfs = m.TraverseDepthFirst();
                Assert.AreEqual("1 2 4 5 6 3 7 8 ", resultDfs);
            }

            [TestMethod]
            public void Test2()
            {
                var q = new Queue<int>();
                q.Enqueue(1);
                q.Enqueue(2);
                q.Enqueue(3);

                var t1 = q.Dequeue();
                var t2 = q.Dequeue();
                var t3 = q.Dequeue();
            }
        }
    }
}
