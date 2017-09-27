using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Euler
{
    // Lexicographic permutations
    // Problem 24
    // A permutation is an ordered arrangement of objects.
    // For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4. 
    // If all of the permutations are listed numerically or alphabetically, we call it lexicographic order.
    // The lexicographic permutations of 0, 1 and 2 are:
    // 012   021   102   120   201   210
    // What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?

    [TestClass]
    public class Problem024_Lexicographical_permutations
    {
        [TestMethod]
        public void Test()
        {
            var p = new Math.Permutation<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 1000000 - 1); // -1 because my implementation is 0-based
            var s = p.ToString().Replace(" ", "");
            Assert.AreEqual("2783915460", s);
        }
    }
}