using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Euler
{
    // If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
    // Find the sum of all the multiples of 3 or 5 below 1000.
    [TestClass]
    public class Problem001_Multiples_of_3_and_5
    {
        [TestMethod]
        public void Problem1_Multiples_Of_3_And_5()
        {
            var s1 = Problem001_Multiples_of_3_and_5.SimpleSolution(100);
            var o1 = Problem001_Multiples_of_3_and_5.OptimizedSolution(100);

            var s2 = Problem001_Multiples_of_3_and_5.SimpleSolution(1000);
            var o2 = Problem001_Multiples_of_3_and_5.OptimizedSolution(1000);

            Assert.AreEqual(s1, o1);
            Assert.AreEqual(s2, o2);
            Assert.AreEqual(233168, o2);
        }

        public static long SimpleSolution(long target)
        {
            long sum = 0;
            for (long i = 1; i < target; i++)
            {
                if (i % 3 == 0 || i % 5 == 0) sum += i;
            }
            return sum;
        }

        public static long OptimizedSolution(long target)
        {
            //1. observe that I am summing:
            //     3 + 6 + 9 + 12 + 15 + 18 +          ...  + 999
            // =   1*3 + 2*3 + 3*3 + 4*3 + 5*3 + 6*3 + ...  + 333*3
            // = 3*(1 + 2 + 3 + ... + 333)

            //     5 + 10 + 15 + 20 + 25 + 30 +          ...  + 995
            // =   1*5 + 2*5 + 3*5 + 4*5 + 5*5 + 6*5 + ...  + 199*5
            // = 3*(1 + 2 + 3 + ... + 333)

            // 2. Observe that 333 = 1000 \ 3
            //                 199 = 1000 \ 5
            
            var ret = SumDividedBy(3, target) + SumDividedBy(5, target);
            
            // But this way I have counted the numbers divived by 3 AND 5 (3*5=15)
            // Therefore subtract those divided by 3 AND 5
            ret -= SumDividedBy(15, target);
            return ret;
        }

        private static long SumDividedBy(int n, long target)
        {
            long p = (target - 1) / n;
            var ret = n*p*(p + 1)/2;
            return ret;
        }
    }
}