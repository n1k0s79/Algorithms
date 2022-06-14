using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeSignal
{
    [TestClass]
    public class AlternatingSums
    {
        [TestMethod]
        public void Test()
        {
            var k = solution(new int[] { 50, 60, 60, 45, 70 });            
            // 50 + 60 + 45 = 155
        }

        int[] solution(int[] a)
        {
            var sum1 = a.Where((item, index) => index % 2 == 0).Sum();
            var sum2 = a.Where((item, index) => index % 2 == 1).Sum();
            return new int[] { a.Where((item, index) => index % 2 == 0).Sum(), a.Where((item, index) => index % 2 == 1).Sum() };
        }
    }
}
