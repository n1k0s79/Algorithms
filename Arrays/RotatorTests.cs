using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Arrays
{
    [TestClass]
    public class RotatorTests
    {
        [TestMethod]
        public void Simple()
        {
            var a = ArrayOf5;
            Assert.AreEqual("1 2 3 4 5", a.ToString<int>());
            Rotator.Rotate(a, 1, Rotator.Directions.Right);
            Assert.AreEqual("5 1 2 3 4", a.ToString<int>());

            a = ArrayOf5;
            Rotator.Rotate(a, 3, Rotator.Directions.Right);
            Assert.AreEqual("3 4 5 1 2", a.ToString<int>());                       
        }

        [TestMethod]
        public void Small()
        {
            var a = new int[] { 1, 2, 3, 4, 5, 6 };
            Rotator.Rotate(a, 1);
            Assert.AreEqual("2 3 4 5 6 1", a.ToString<int>());

            a = new int[] { 1, 2, 3, 4, 5, 6 };
            Rotator.Rotate(a, 2);
            Assert.AreEqual("3 4 5 6 1 2", a.ToString<int>());

            a = new int[] { 1, 2, 3, 4, 5, 6 };
            Rotator.Rotate(a, 3);
            Assert.AreEqual("4 5 6 1 2 3", a.ToString<int>());

            a = new int[] { 1, 2, 3, 4, 5, 6 };
            Rotator.Rotate(a, 4);
            Assert.AreEqual("5 6 1 2 3 4", a.ToString<int>());

            a = new int[] { 1, 2, 3, 4, 5, 6 };
            Rotator.Rotate(a, 5);
            Assert.AreEqual("6 1 2 3 4 5", a.ToString<int>());

            a = new int[] { 1, 2, 3, 4, 5, 6 };
            Rotator.Rotate(a, 6);
            Assert.AreEqual("1 2 3 4 5 6", a.ToString<int>());
        }

        [TestMethod]
        public void Small2()
        {
            var a = new int[] { 1, 2, 3, 4, 5 };
            Rotator.Rotate(a, 2, Rotator.Directions.Right);
            Assert.AreEqual("4 5 1 2 3", a.ToString<int>());
        }


        [TestMethod]
        public void Single()
        {
            var a = new int[] { 999 };
            Rotator.Rotate(a, 3, Rotator.Directions.Right);
            Assert.AreEqual("999", a.ToString<int>());

            Rotator.Rotate(a, 12, Rotator.Directions.Right);
            Assert.AreEqual("999", a.ToString<int>());
        }


        [TestMethod]
        public void Double()
        {
            var a = new int[] { 1, 2 };
            Rotator.Rotate(a, 1, Rotator.Directions.Right);
            Assert.AreEqual("2 1", a.ToString<int>());
        }


        [TestMethod]
        public void NullInput()
        {
            int[] a = null;
            Rotator.Rotate(a, 1, Rotator.Directions.Right);
        }

        [TestMethod]
        public void RotateMoreThanN()
        {
            var a = new int[] { 1, 2, 3, 4, 5 };
            Rotator.Rotate(a, 5, Rotator.Directions.Right);
            Assert.AreEqual("1 2 3 4 5", a.ToString<int>());

            Rotator.Rotate(a, 6, Rotator.Directions.Right);
            Assert.AreEqual("5 1 2 3 4", a.ToString<int>());
        }

        [TestMethod]
        public void EmptyArray()
        {
            var a = new int[] {  };
            Rotator.Rotate(a, 5, Rotator.Directions.Right);
        }

        [TestMethod]
        public void CompareResults2()
        {
            var rnd = new Random(DateTime.Now.Second);
            for(int k = 0; k < 10; k++)
            {
                var a = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                var b = (int[])a.Clone();
                Rotator.RightRotateR(a, k);
                Rotator.Rotate<int>(b, k, Rotator.Directions.Right);
                Assert.AreEqual(a.ToString<int>(), b.ToString<int>());
            }
        }

        //[TestMethod]
        //public void RotationsRight2()
        //{
        //    var a = SmallArray;
        //    Rotator.RotateRight(a, 1);
        //    Assert.AreEqual("9 1 2 3 4 5 6 7 8", ArrayToString(a));

        //    a = SmallArray;
        //    Rotator.RotateRight(a, 3);
        //    Assert.AreEqual("7 8 9 1 2 3 4 5 6", ArrayToString(a));

        //    a = SmallArray;
        //    Rotator.RotateRight(a, 13);
        //    Assert.AreEqual("6 7 8 9 1 2 3 4 5", ArrayToString(a));
        //}

        //[TestMethod]
        //public void Rotations()
        //{
        //    Assert.AreEqual("1 2 3 4 5 6 7 8 9", ArrayToString(Rotator.GetRotated(SmallArray, 0, Rotator.Directions.Right)));
        //    Assert.AreEqual("1 2 3 4 5 6 7 8 9", ArrayToString(Rotator.GetRotated(SmallArray, 0, Rotator.Directions.Left)));

        //    Assert.AreEqual("9 1 2 3 4 5 6 7 8", ArrayToString(Rotator.GetRightRotated(SmallArray, 1)));
        //    Assert.AreEqual("8 9 1 2 3 4 5 6 7", ArrayToString(Rotator.GetRightRotated(SmallArray, 2)));
        //    Assert.AreEqual("7 8 9 1 2 3 4 5 6", ArrayToString(Rotator.GetRightRotated(SmallArray, 3)));
        //    Assert.AreEqual("6 7 8 9 1 2 3 4 5", ArrayToString(Rotator.GetRightRotated(SmallArray, 4)));
        //    Assert.AreEqual("5 6 7 8 9 1 2 3 4", ArrayToString(Rotator.GetRightRotated(SmallArray, 5)));
        //    Assert.AreEqual("4 5 6 7 8 9 1 2 3", ArrayToString(Rotator.GetRightRotated(SmallArray, 6)));
        //    Assert.AreEqual("3 4 5 6 7 8 9 1 2", ArrayToString(Rotator.GetRightRotated(SmallArray, 7)));
        //    Assert.AreEqual("2 3 4 5 6 7 8 9 1", ArrayToString(Rotator.GetRightRotated(SmallArray, 8)));
        //    Assert.AreEqual("1 2 3 4 5 6 7 8 9", ArrayToString(Rotator.GetRightRotated(SmallArray, 9)));

        //    Assert.AreEqual("9 1 2 3 4 5 6 7 8", ArrayToString(Rotator.GetRightRotated(SmallArray, 10)));
        //    Assert.AreEqual("8 9 1 2 3 4 5 6 7", ArrayToString(Rotator.GetRightRotated(SmallArray, 11)));
        //    Assert.AreEqual("7 8 9 1 2 3 4 5 6", ArrayToString(Rotator.GetRightRotated(SmallArray, 12)));
        //    Assert.AreEqual("6 7 8 9 1 2 3 4 5", ArrayToString(Rotator.GetRightRotated(SmallArray, 13)));
        //    Assert.AreEqual("5 6 7 8 9 1 2 3 4", ArrayToString(Rotator.GetRightRotated(SmallArray, 14)));
        //    Assert.AreEqual("4 5 6 7 8 9 1 2 3", ArrayToString(Rotator.GetRightRotated(SmallArray, 15)));
        //    Assert.AreEqual("3 4 5 6 7 8 9 1 2", ArrayToString(Rotator.GetRightRotated(SmallArray, 16)));
        //    Assert.AreEqual("2 3 4 5 6 7 8 9 1", ArrayToString(Rotator.GetRightRotated(SmallArray, 17)));
        //    Assert.AreEqual("1 2 3 4 5 6 7 8 9", ArrayToString(Rotator.GetRightRotated(SmallArray, 18)));
        //}

        //[TestMethod]
        //public void RotationsLeft()
        //{
        //    Assert.AreEqual("1 2 3 4 5 6 7 8 9", ArrayToString(Rotator.GetLeftRotated(SmallArray, 0)));
        //    Assert.AreEqual("2 3 4 5 6 7 8 9 1", ArrayToString(Rotator.GetLeftRotated(SmallArray, 1)));
        //    Assert.AreEqual("3 4 5 6 7 8 9 1 2", ArrayToString(Rotator.GetLeftRotated(SmallArray, 2)));
        //    Assert.AreEqual("4 5 6 7 8 9 1 2 3", ArrayToString(Rotator.GetLeftRotated(SmallArray, 3)));
        //    Assert.AreEqual("5 6 7 8 9 1 2 3 4", ArrayToString(Rotator.GetLeftRotated(SmallArray, 4)));
        //    Assert.AreEqual("6 7 8 9 1 2 3 4 5", ArrayToString(Rotator.GetLeftRotated(SmallArray, 5)));
        //    Assert.AreEqual("7 8 9 1 2 3 4 5 6", ArrayToString(Rotator.GetLeftRotated(SmallArray, 6)));
        //    Assert.AreEqual("8 9 1 2 3 4 5 6 7", ArrayToString(Rotator.GetLeftRotated(SmallArray, 7)));
        //    Assert.AreEqual("9 1 2 3 4 5 6 7 8", ArrayToString(Rotator.GetLeftRotated(SmallArray, 8)));

        //    Assert.AreEqual("1 2 3 4 5 6 7 8 9", ArrayToString(Rotator.GetLeftRotated(SmallArray, 9)));
        //    Assert.AreEqual("2 3 4 5 6 7 8 9 1", ArrayToString(Rotator.GetLeftRotated(SmallArray, 10)));
        //    Assert.AreEqual("3 4 5 6 7 8 9 1 2", ArrayToString(Rotator.GetLeftRotated(SmallArray, 11)));
        //    Assert.AreEqual("4 5 6 7 8 9 1 2 3", ArrayToString(Rotator.GetLeftRotated(SmallArray, 12)));
        //    Assert.AreEqual("5 6 7 8 9 1 2 3 4", ArrayToString(Rotator.GetLeftRotated(SmallArray, 13)));
        //    Assert.AreEqual("6 7 8 9 1 2 3 4 5", ArrayToString(Rotator.GetLeftRotated(SmallArray, 14)));
        //    Assert.AreEqual("7 8 9 1 2 3 4 5 6", ArrayToString(Rotator.GetLeftRotated(SmallArray, 15)));
        //    Assert.AreEqual("8 9 1 2 3 4 5 6 7", ArrayToString(Rotator.GetLeftRotated(SmallArray, 16)));
        //    Assert.AreEqual("9 1 2 3 4 5 6 7 8", ArrayToString(Rotator.GetLeftRotated(SmallArray, 17)));
        //    Assert.AreEqual("1 2 3 4 5 6 7 8 9", ArrayToString(Rotator.GetLeftRotated(SmallArray, 18)));
        //}

        //[TestMethod]
        //public void RotationsLeft2()
        //{
        //    var a = SmallArray;
        //    Rotator.RotateLeft(a, 1);
        //    Assert.AreEqual("2 3 4 5 6 7 8 9 1", ArrayToString(a));

        //    a = SmallArray;
        //    Rotator.RotateLeft(a, 3);
        //    Assert.AreEqual("4 5 6 7 8 9 1 2 3", ArrayToString(a));

        //    a = SmallArray;
        //    Rotator.RotateLeft(a, 13);
        //    Assert.AreEqual("5 6 7 8 9 1 2 3 4", ArrayToString(a));
        //}

        //[TestMethod]
        //public void ExtremeNumberOfRotations()
        //{
        //    var a = SmallArray;
        //    Rotator.RotateLeft(a, 100000000);
        //    Assert.AreEqual("2 3 4 5 6 7 8 9 1", ArrayToString(a));

        //    a = SmallArray;
        //    Rotator.RotateLeft(a, int.MaxValue);
        //    Assert.AreEqual("2 3 4 5 6 7 8 9 1", ArrayToString(a));
        //}

        //[TestMethod]
        //public void LargeArrayTests()
        //{
        //    var a = LargeArray;
        //    Rotator.RotateLeft(a, 1000);
        //    Assert.AreEqual(1000, a[0]);
        //}

        //[TestMethod]
        //public void Juggle()
        //{
        //    var a = SmallArray;
        //    Rotator.Attempt6_LeftRotateByN_Failed(a, 2);
        //}

        #region Test data

        private int[] TinyArray
        {
            get { return new int[] { 1, 2, 3 }; }
        }

        private int[] SmallArray
        {
            get { return new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9}; }
        }

        private int[] SmallArray2
        {
            get { return new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; }
        }

        private int[] ArrayOf5
        {
            get { return new [] { 1, 2, 3, 4, 5 }; }
        }

        private int[] LargeArray
        {
            get
            {
                var ret = new int[1000000];
                for (int i = 0; i < ret.Length - 1; i++) ret[i] = i;
                return ret;
            }
        }

        #endregion
    }
}