using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRank
{
    [TestClass]
    public class DrawingBook
    {
        [TestMethod]
        public void TestSolution()
        {
            var a = Solve(6, 2);
            var b = Solve(5, 4);
        }
        private static int Solve(int n, int p)
        {
            // starting from the start

            // if I turn 0 times I get to pages 0,1
            // if I turn 1 times I get to pages 2,3
            // if I turn 2 times I get to pages 4,5
            // if I turn 3 times I get to pages 6,7
            // if I turn 4 times I get to pages 8,9
            // if I turn 5 times I get to pages 10,11            
            // if I turn k times I get to pages 2k, 2k+1                       

            // to get to page p I need to turn p/2 times

            // A book with n pages, total turns: n/2

            // to get to page p starting from the end
            // I need to turn (totalTurns - turnsFromStart) times

            int totalTurns = n / 2;
            int turnsFromStart = p / 2;
            int turnsFromEnd = totalTurns - turnsFromStart;
            return Math.Min(turnsFromStart, turnsFromEnd);
        }
    }
}
