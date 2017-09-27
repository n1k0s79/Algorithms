using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    [TestClass]
    public class ElectronicsShop
    {
        static int getMoneySpent(int[] keyboards, int[] drives, int maxAmount)
        {
            int max = -1;
            for(int i = 0; i < keyboards.Length; i++)
            {
                for (int j = 0; j < drives.Length; j++)
                {
                    int sum = keyboards[i] + drives[j];
                    if (sum > max && sum <= maxAmount) max = sum;
                }
            }

            return max;
        }

        [TestMethod]
        public void Test()
        {
            var keyboards = new int[] { 3, 1 };
            var drives = new int[] { 5, 2, 8 };
            var a = getMoneySpent(keyboards, drives, 10);
        }
    }
}