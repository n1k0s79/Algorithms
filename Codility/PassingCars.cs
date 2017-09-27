using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codility
{
    [TestClass]
    public class PassingCars
    {   
        /// <summary> strategy: Every time a west-travelling car comes it will pass all previous east-travelling cars </summary>
        public static int solution(int[] A)
        {
            int east = 0;
            int passing = 0;
            foreach (var c in A)
            {
                if (c == 0)
                {
                    east++;
                }
                else
                {
                    passing += east;
                    if (passing > 1000000000) return -1;
                }
            }
            return passing;
        }

        [TestMethod]
        public void TestSolution()
        {
            var A = new int[] { 0, 1, 0, 1, 1 };
            var ret = solution(A);
        }
    }
}