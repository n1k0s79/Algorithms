using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Toptal
{
    [TestClass]
    public class CountOfCarryOperations
    {
        [TestMethod]
        public void TestThis()
        {
            Assert.AreEqual(0, CountCarryOps(900, 11));
            Assert.AreEqual(2, CountCarryOps(65, 55));

            Assert.AreEqual(0, CountCarryOps(123, 456));
            Assert.AreEqual(3, CountCarryOps(555, 555));
            
            Assert.AreEqual(2, CountCarryOps(145, 55));
            Assert.AreEqual(0, CountCarryOps(0, 0));
            Assert.AreEqual(5, CountCarryOps(1, 99999));
            Assert.AreEqual(5, CountCarryOps(999045, 1055));
        }

        public int CountCarryOps(int a, int b)
        {
            int ret = 0;
            var sa = a.ToString();
            var sb = b.ToString();

            int maxDigits = Math.Max(a.ToString().Length, b.ToString().Length);
            for (int i = maxDigits; i > 0; i--)
            {
                int da = 0;
                if (i <= sa.Length) da = int.Parse(sa[i - 1].ToString());
                int db = 0;
                if (i <= sb.Length) db = int.Parse(sb[i - 1].ToString());
                if (da + db >= 10) ret++;
            }

            return ret;
        }                
    }
}
