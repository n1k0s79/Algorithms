using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Interviews.Betsson.Question6
{
    // Μπέρδεμα ήτανε αλλά την απάντησα σωστά
    [TestClass]
    public class Question6
    {
        [TestMethod] 
        public void Test()
        {
            Main();
        }

        void Main()
        {
            EnumA D;
            EnumB C = EnumB.C;
            D = (EnumA)C;
            Assert.AreEqual(EnumA.A, D);
        }

        public enum EnumA
        {
            A, B, C, D
        }

        public enum EnumB { C, D }
    }
}
