using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeWars
{
    [TestClass]
    public class Rot13Kata
    {
        /*
        ROT13 is a simple letter substitution cipher that replaces a letter with the letter 13 letters after it in the alphabet. ROT13 is an example of the Caesar cipher.
        Create a function that takes a string and returns the string ciphered with Rot13. 
        If there are numbers or special characters included in the string, they should be returned as they are. 
        Only letters from the latin/english alphabet should be shifted, like in the original Rot13 "implementation".        
        */

        [TestMethod]
        public void testTest()
        {
            Assert.AreEqual("grfg", Rot13("test"), String.Format("Input: test, Expected Output: grfg, Actual Output: {0}", Rot13("test")));
        }

        [TestMethod]
        public void TestTest()
        {
            Assert.AreEqual("Grfg", Rot13("Test"), String.Format("Input: Test, Expected Output: Grfg, Actual Output: {0}", Rot13("Test")));
        }

        public static string Rot13(string str) => str.ToCharArray()
                .Select(c =>
                {
                    if (!char.IsLetter(c)) return c;
                    var start = (int)(char.IsUpper(c) ? 'A' : 'a');
                    var charIndex = c - start;
                    var offsetIndex = charIndex + 13;
                    var newIndex = offsetIndex % 26;
                    var newValue = newIndex + start;
                    var newChar = (char)newValue;
                    return newChar;
                }).Aggregate(string.Empty, (acc, c) => acc + c);
    }
}
