using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Euler
{
    // Coin sums
    // Problem 31

    // In England the currency is made up of pound, £, and pence, p, and there are eight coins in general circulation:
    //    1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).
    // It is possible to make £2 in the following way:
    //    1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p
    // How many different ways can £2 be made using any number of coins?

   [TestClass]
    public class Problem031_Coin_sums
    {
        [TestMethod]
        public void TestIt()
        {
            //var coins = new decimal[] { 0.01M, 0.02M, 0.05M, 0.1M, 0.2M, 0.5M, 1M, 2M };
            var coins = new decimal[] { 0.2M, 0.5M, 1M, 2M };
            var res = count(coins, coins.Length, 10M);
        }

        // Returns the count of ways we can sum  S[0...m-1] coins to get sum n
        private int count(decimal[] coins, int m, decimal value)
        {
            // If n is 0 then there is 1 solution (do not include any coin)
            if (value == 0) return 1;

            // If n is less than 0 then no solution exists
            if (value < 0) return 0;

            // If there are no coins and n is greater than 0, then no solution exist
            if (m <= 0 && value >= 0.01M) return 0;

            // count is sum of solutions (i) including S[m-1] (ii) excluding S[m-1]
            return count(coins, m - 1, value) + count(coins, m, value - coins[m - 1]);
        }

        private static decimal [] values = new decimal[] { 0.01M, 0.02M, 0.05M, 0.1M, 0.2M, 0.5M, 1M, 2M };

        private int BruteForce2()
        {
            int target = 200;
            int ways = 0;

            for (int a = target; a >= 0; a -= 200)
            {
                for (int b = a; b >= 0; b -= 100)
                {
                    for (int c = b; c >= 0; c -= 50)
                    {
                        for (int d = c; d >= 0; d -= 20)
                        {
                            for (int e = d; e >= 0; e -= 10)
                            {
                                for (int f = e; f >= 0; f -= 5)
                                {
                                    for (int g = f; g >= 0; g -= 2)
                                    {
                                        ways++;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return ways;
        }

        private int BruteForce1()
        {
            long iterations = 0;
            int total = 0;
            for (int e2 = 0; e2 <= 1; e2++)
            {
                for (int e1 = 0; e1 <= 2; e1++)
                {
                    for (int d50 = 0; d50 <= 4; d50++)
                    {
                        for (int d20 = 0; d20 <= 10; d20++)
                        {
                            for (int d10 = 0; d10 <= 20; d10++)
                            {
                                for (int d5 = 0; d5 <= 40; d5++)
                                {
                                    for (int d2 = 0; d2 <= 100; d2++)
                                    {
                                        for (int d1 = 0; d1 <= 200; d1++)
                                        {
                                            iterations++;
                                            var sum = 2 * e2 + e1 + 0.5 * d50 + 0.2 * d20 + 0.1 * d10 + 0.05 * d5 + 0.02 * d2 + 0.01 * d1;
                                            if (sum == 2) total++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return 0;
        }

     

        private int BruteForce()
        {
            int total = 0;
            decimal rem = 2;
            while (true)
            {
                decimal maxPossible = GetMaxPossible(rem);
                rem -= maxPossible;
                if (rem == 0)
                {
                    total++;
                    rem = 2;
                }
            }

            foreach (var v in values)
            {
                int maxItems = (int)(2 / v);

                for (int items = 0; items <= maxItems; items++)
                {

                }
            }

            return 0;
        }

        private decimal GetMaxPossible(decimal remaining)
        {
            for(int i = values.Length - 1; i >= 0; i--)
            {
                if (values[i] <= remaining) return values[i];
            }

            return 0;
        }
    }
}