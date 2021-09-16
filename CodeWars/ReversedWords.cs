using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeWars
{
    [TestClass]
    public class ReversedWords
    {
        /*
        Complete the solution so that it reverses all of the words within the string passed in.
        Example:
        "The greatest victory is that which requires no battle" --> "battle no requires which that is victory greatest The"         
        */

        [TestMethod]
        public void BasicTests()
        {
            Assert.AreEqual("world! hello", ReverseWords("hello world!"));
            Assert.AreEqual("this like speak doesn't yoda", ReverseWords("yoda doesn't speak like this"));
            Assert.AreEqual("foobar", ReverseWords("foobar"));
            Assert.AreEqual("kata editor", ReverseWords("editor kata"));
            Assert.AreEqual("boat your row row row", ReverseWords("row row row your boat"));
        }

        public static string ReverseWords(string str)
        {
            var words = str.Split().ToList();
            words.Reverse();
            return string.Join(' ', words);
        }
    }
}
