using System.Collections.Generic;

namespace Math
{
    public class Divisors
    {
        public static List<int> GetDivisors(int number, bool includeSame = true)
        {
            var ret = new List<int>() { 1 };            
            int i = 2;
            int limit = (int)System.Math.Sqrt(number);

            while(i <= limit) 
            {
                if (number % i == 0)
                {
                    ret.Add(i);
                    if (i != (number / i))
                    {
                        if (i * i != number) ret.Add(number / i);
                    }
                }

                i++;
            }

            if (includeSame && number > 1) ret.Add(number);

            return ret;
        }

        public static int GetSumOfDivisors(int number, bool includeSame = true)
        {
            var ret = 1;
            int i = 2;
            int limit = (int)System.Math.Sqrt(number);

            while (i <= limit)
            {
                if (number % i == 0)
                {
                    ret += i;
                    if (i != (number / i))
                    {
                        if (i * i != number) ret += number / i;
                    }
                }

                i++;
            }

            if (includeSame && number > 1) ret += number;

            return ret;
        }

        /// <summary> Returns the number of integers below N that are eveny divided by K </summary>
        public static int CountDivisors(int N, int K)
        {
            return N / K;
        }

        /// <summary> Returns the number of integers that eveny divide n </summary>
        public static int CountDivisors(int n)
        {
            // the number of divisors is given by the formula:
            // (a+1) * (b+1) * (c+1) * ... where a,b,c are the exponents of the prime factors
            var f = new Primes.Factorized((ulong)n);
            int ret = 1;
            foreach(var p in f.Factors) ret *= p.Exponent + 1;
            return ret;
        }
    }
}
