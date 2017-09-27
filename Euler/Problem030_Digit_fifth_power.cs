using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Euler
{

    // the challenge here was to find a way to stop the loop
    // ... and speed up the calculations by precalculating the powers
   [TestClass]
    public class Problem030_Digit_fifth_power
    {
        [TestMethod]
        public void TestIt()
        {
            Assert.AreEqual(19316, SumFound(4));
            Assert.AreEqual(443839, SumFound(5));
        }

        private static int SumFound(int power)
        {
            var powers = new int[10];
            for (int i = 1; i < 10; i++) powers[i] = (int)System.Math.Pow(i, power);

            int sum = 0;
            int upperLimit = GetUpperLimit(powers);
            for (int i = 10; i < upperLimit; i++)
            {
                int ds = GetDigitsPoweredSum(i, powers);
                if (ds == i) sum += i;
            }

            return sum;
        }

        private static int GetUpperLimit(int[] powers)
        {
            int digits = 2;
            while (true)
            {
                int minPossibleSumOfPowers = digits;
                int maxPossibleSumOfPowers = digits * powers[9];
                int minPossibleNumber = int.Parse("1".PadRight(digits, '0'));
                int maxPossibleNumber = int.Parse(new string('9', digits));

                // the maximum possible sum of the fourth - powered digits of a 6 digit number is 39366
                // but the lowest possible 6 - digits number is 100000

                if (maxPossibleSumOfPowers < minPossibleNumber) return minPossibleNumber;
                digits++;
            }
        }

        private static int GetDigitsPoweredSum(int n, int[] powers)
        {
            var s = n.ToString();
            int sum = 0;
            foreach(var c in s)
            {
                sum += powers[int.Parse(c.ToString())];
                if (sum > n) return -1;
            }

            return sum;
        }
    }
}