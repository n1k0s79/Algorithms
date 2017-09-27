using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    [TestClass]
    public class CamelCase
    {
        [TestMethod]
        public void TestCamelCase()
        {
            var ret = Strings.Util.SplitCamelCase("stringIsCamelCase");
            Assert.AreEqual(4, ret.Count);
            Assert.AreEqual("string", ret[0]);            
            Assert.AreEqual("Is", ret[1]);
            Assert.AreEqual("Camel", ret[2]);
            Assert.AreEqual("Case", ret[3]);

            ret = Strings.Util.SplitCamelCase("asdflkjahdsflkjhasd");
            Assert.AreEqual(1, ret.Count);
            Assert.AreEqual("asdflkjahdsflkjhasd", ret[0]);

            ret = Strings.Util.SplitCamelCase("ABCD");
            Assert.AreEqual(4, ret.Count);
            Assert.AreEqual("A", ret[0]);
            Assert.AreEqual("B", ret[1]);
            Assert.AreEqual("C", ret[2]);
            Assert.AreEqual("D", ret[3]);

            ret = Strings.Util.SplitCamelCase("endsWithCapitaL");
            Assert.AreEqual(4, ret.Count);
            Assert.AreEqual("ends", ret[0]);
            Assert.AreEqual("With", ret[1]);
            Assert.AreEqual("Capita", ret[2]);
            Assert.AreEqual("L", ret[3]);

            ret = Strings.Util.SplitCamelCase("");
            Assert.AreEqual(0, ret.Count);
        }
    }
}
