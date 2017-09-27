using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math
{
    public class LeastCommonMultiple
    {
        /// <summary> Innefficient </summary>
        public static long Calculate(params int[] numbers)
        {
            var max = numbers.Max();
            var other = numbers.Where(x => x != max).ToArray();
            int p = 1;
            while (true)
            {
                long product = max * p;
                if (IsDivisibleByAll(product, other)) return product;
                p++;
            }
        }

        private static bool IsDivisibleByAll(long t, params int[] all)
        {
            return all.All(a => t%a == 0);
        }

        /// <summary> MCP with factorization </summary>
        public static ulong CalculateF(params int[] numbers)
        {
            var f = numbers.Select(n => new Primes.Factorized((ulong) n)).ToList();
            return Primes.Factorized.LeastCommonMultiple(f);
        }
    }
}