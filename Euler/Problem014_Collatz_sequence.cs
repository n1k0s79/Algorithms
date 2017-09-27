using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Euler
{  
    [TestClass]
    public class Problem014_Collatz_sequence
    {
        //The following iterative sequence is defined for the set of positive integers:
        //n → n/2 (n is even)
        //n → 3n + 1 (n is odd)
        //Using the rule above and starting with 13, we generate the following sequence:
        //13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1

        //It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.
        //Which starting number, under one million, produces the longest chain?
        //NOTE: Once the chain starts the terms are allowed to go above one million.
            
        [TestMethod]
        public void TestSolution()
        {
            int maxLength = 0;
            int maxN =0;
            for(int i=1; i<1000000; i++)
            {
                int l = Math.CollatzSequence.GetLength(i);
                if (l > maxLength)
                {
                    maxLength = l;
                    maxN = i;
                }
            }

            Assert.AreEqual(525, maxLength);
            Assert.AreEqual(837799, maxN);

            // NOTE: 113383 was the first integer for which the collatz sequence contains a number (2482111348) greater that int.MaxValue (2147483647)
            // this almost went unnoticed!
        }
    }
}