using System;
using System.Collections.Generic;
using System.Linq;

namespace Math
{
    public class Primes
    {
        public const long LargestLongPrime = 67280421310721;
        public const int LargestIntPrime = 2147483647;

        public static IEnumerable<ulong> GenerateUpTo(ulong max)
        {
            yield return 2; // even numbers cannot be prime (except 2 of course)

            for (ulong i = 3; i < max; i+=2) // so start from 3 and go up two at a time
            {
                if (IsPrime(i)) yield return i;
            }
        }

        public static ulong GenerateNth(int n)
        {
            int count = 1;
            ulong t = 3;
            while (count < n)
            {
                if (IsPrime_Unoptimized(t)) count ++;
                t += 2;
            }
            
            return t;
        }

        public static List<ulong> GenerateFirst(int n)
        {
            var ret = new List<ulong>() {2};
            ulong t = 3;
            while (ret.Count < n)
            {
                if (IsPrime_Unoptimized(t)) ret.Add(t);
                t += 2;
            }
            return ret;
        }

        public static bool IsComposite(ulong number)
        {
            if (number <= 1) throw new Exception("0 and 1 are neither composite nor prime!");
            return !IsPrime_Unoptimized(number);
        }

        /// <summary> Returns true if the number is prime </summary>
        /// <param name="number"> A number is prime if it is divisible only by itself and 1</param>
        /// <remarks> So if I find a number that divides it then I know that it is not prime </remarks>
        public static bool IsPrime_Unoptimized(ulong number)
        {
            if (number <= 1) throw new Exception("0 and 1 are neither composite nor prime!");

            // If the number HAS a factor then it is not prime
            // So if I find a factor I am done.
            
            // 3 * 5 = 15
            // 19 

            // BUT: No number will have a prime factor that's greater than its own square root, 
            // so I can stop my divisions at that point. 
            // For instance, I can stop checking potential factors of the number 29 after 5.
            ulong limit = (ulong)System.Math.Sqrt(number);

            for (ulong n = 2; n <= limit; n++)
            {
                if (number%n == 0 && number != 2) return false;
            }

            return true;
        }

        public static bool IsPrime(ulong n)
        {
            // Some useful facts:
            // 1 is not a prime.
            // All primes except 2 are odd.
            // All primes greater than 3 can be written in the form 6k+/-1.
            // Any number n can have only one primefactor greater than n .
            // The consequence for primality testing of a number n is: if we cannot find a number f less than
            // or equal n that divides n then n is prime: the only primefactor of n is n itself
            if (n <= 1) return false;
            if (n < 4) return true; //2 and 3 are prime
            if (n %2==0) return false; // even numbers cannot be prime (except 2 which is caught above)
            if (n < 9) return true;  //we have already excluded 4,6 and 8.
            if (n%3 == 0) return false;

            ulong r = (ulong)System.Math.Floor(System.Math.Sqrt(n)); // n rounded to the greatest integer r so that r*r<=n
            ulong f = 5;
            while (f <= r)
            {
                if (n%f == 0) return false;
                if (n%(f + 2) == 0) return false;
                f+=6;
            }
            return true; // (in all other cases)
        }

        /// <summary> Returns a list of the prime factors of number </summary>
        /// <remarks> Strategy:
        /// Test if the number is divided by factor = 2, 3, 4, 5, 6...
        /// If it IS divided then divide it as many times as possible with theis specific factor
        /// </remarks>
        public static List<ulong> Factorize(ulong number)
        {
            var ret = new List<ulong>();
            FindPrimeFactors(number, p => ret.Add(p));
            return ret;
        }

        public class Factorized
        {
            public readonly ulong Original;
            public readonly List<Factor> Factors;

            public Factorized(ulong number)
            {
                this.Original = number;
                this.Factors = new List<Factor>();
                FindPrimeFactors(number, p => AddFactor((int)p));
            }


            private void AddFactor(int factor)
            {
                var f = this.Factors.FirstOrDefault(x => x.Number == factor);
                if (f == null)
                {
                    Factors.Add(new Factor(factor));
                }
                else
                {
                    f.IncrementPower();
                }
            }

            public override string ToString()
            {
                return this.Original + " = " + string.Join(" * ", this.Factors.ConvertAll(x => x.ToString()));
            }

            /// <summary> Calculates the least common multiple of a list of factorized numbers </summary>
            public static ulong LeastCommonMultiple(List<Factorized> factorizedNumbers)
            {
                // calculate the product of all factors with the greatest power
                Dictionary<int, int> factors = new Dictionary<int, int>();
                foreach (var f in factorizedNumbers)
                {
                    foreach (var c in f.Factors)
                    {
                        if (factors.ContainsKey(c.Number))
                        {
                            factors[c.Number] = System.Math.Max(factors[c.Number], c.Exponent);
                        }
                        else
                        {
                            factors[c.Number] = c.Exponent;
                        }
                    }
                }

                ulong ret = 1;
                foreach (var k in factors)
                {
                    ret *= (ulong)System.Math.Pow(k.Key, k.Value);
                }

                return ret;
            }
        }

        public class Factor
        {
            public readonly int Number;
            private int _power;

            public Factor(int number, int power = 1)
            {
                this.Number = number;
                this._power = power;
            }

            public ulong Product { get { return (ulong)System.Math.Pow(this.Number, this.Exponent); } }

            public override string ToString()
            {
                return this.Number + "^" + this.Exponent;
            }

            public int Exponent { get { return this._power; } }

            public void IncrementPower()
            {
                this._power++;
            }
        }

        /// <summary> Returns a list of the prime factors of number </summary>
        /// <remarks> Strategy:
        /// Test if the number is divided by factor = 2, 3, 4, 5, 6...
        /// If it IS divided then divide it as many times as possible with theis specific factor
        /// </remarks>
        private static void FindPrimeFactors_Unoptimized(ulong number, Action<ulong> factorFound)
        {
            while (number % 2 == 0) // first check 
            {
                factorFound(2);
                number /= 2;
            }

            ulong maxFactor = (ulong)System.Math.Sqrt(number);
            ulong factor = 3;
            while (number > 1 && factor <= maxFactor)
            {
                while (number % factor == 0)
                {
                    factorFound(factor);
                    number /= factor;
                    maxFactor = (ulong)System.Math.Sqrt(number);
                }
                factor += 2;
            }
            // all factors will necessarily be prime because all the smaller ones have been removed
        }
      
        /// <summary> Returns a list of the prime factors of number </summary>
        /// <remarks> Two optimizations compared to the unoptimized (first check for 2, max square root)
        /// </remarks>
        private static void FindPrimeFactors(ulong number, Action<ulong> factorFound)
        {
            while (number % 2 == 0) // first check for 2. This way, in the following loop I can advance factor by 2 instead of 1 and cut the required time in half
            {
                factorFound(2);
                number /= 2;
            }

            // 1. Every number n can have at most one prime factor greater than sqrt(n)
            // 2. If after dividing the remaining number is larger than sqrt(n) then I know that the remaining number is a prime factor
            ulong maxFactor = (ulong)System.Math.Sqrt(number);
            ulong factor = 3;
            while (number > 1 && factor <= maxFactor)
            {
                if (number%factor == 0)
                {
                    factorFound(factor);
                    number /= factor;
                    while (number % factor == 0)
                    {
                        factorFound(factor);
                        number /= factor;
                    }
                    maxFactor = (ulong)System.Math.Sqrt(number);
                }

                factor += 2;
            }

            // Note that if after dividing the remaining number is larger than sqrt(n) then I know that the remaining number is a prime factor
            if (number != 1) factorFound(number);
        }
      
        /// <summary> Find the largest prime factor of number </summary>
        public static ulong LargestPrimeFactor(ulong number)
        {
            ulong ret = 1;
            FindPrimeFactors(number, p => ret = p);
            return ret;
        }
        
        /// <summary> Generates prime numbers up to max</summary>
        /// <remarks> κόσκινον Ἐρατοσθένους
        /// This algorithm cannot run when max > Int.MaxValue
        /// It has a O(max) space complexity </remarks>
        public static List<int> GenerateUpTo(int max)
        {
            int d = max + 1;
            Number[] numbers = new Number[max + 1];
            for (int i = 2; i < numbers.Length; i++) numbers[i] = new Number(i);

            int smax = (int)System.Math.Sqrt(max);
            
            for (int i = 2; i <= smax; i++)
            {
                Number a = numbers[i];
                if (a.IsPrime)
                {
                    for (int j = i * i; j < numbers.Length; j += i)
                    {
                        numbers[j].IsPrime = false;
                    }
                }
            }

            var ret = new List<int>();
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i].IsPrime) ret.Add(i);
            }
            return ret;
        }

        struct Number
        {
            public int Value;
            public bool IsPrime;

            public Number(int value)
            {
                this.Value = value;
                this.IsPrime = true;
            }

            public override string ToString()
            {
                return this.Value + ", " + this.IsPrime;
            }
        }

        /// <summary> Find the largest prime factor of number </summary>
        public static ulong LargestPrimeFactor_Slow(ulong number)
        {
            // start searching for a prime factor by going down from the number's square root
            for (var t = (ulong)System.Math.Sqrt(number); t > 0; t--)
            {
                if (number % t == 0 && IsPrime_Unoptimized(t)) return t;
            }

            return 1;
        }

        /// <summary> The numbers are coprime if the only positive number that divides all of them is 1 </summary>
        public static bool Coprime(IEnumerable<int> numbers)
        {
            return GreatestCommonDivisor.Gcd(numbers.ToArray()) == 1;
        }
    }
}