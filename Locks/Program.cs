using System;
using System.Linq;

namespace UnlockKey
{
    class Program
    {
        static void Main(string[] args)
        {
            var unlockKey = Enumerable.Range(0, 999)
                .Select(i => new Number(i))
                .FirstOrDefault(n => n.OneMatchingDigitInCorrectPosition(682) &&
                                     n.OneMatchingDigitInWrongPosition(614) &&
                                     n.TwoMatchingDigitsInWrongPosition(206) &&
                                     n.AllWrong(738) &&
                                     n.OneMatchingDigitInWrongPosition(780));

            Console.WriteLine(unlockKey.ToString());
        }
    }

    class Number
    {
        private string s;
        public Number(int i) { s = i.ToString().PadLeft(3, '0'); }

        int[] ToIntArray(int n) => n.ToString().Select(c => int.Parse(c.ToString())).ToArray();
        public bool OneMatchingDigitInWrongPosition(int number) => MatchingDigitsInWrongPosition(number, 1);

        public bool TwoMatchingDigitsInWrongPosition(int number) => MatchingDigitsInWrongPosition(number, 2);

        bool MatchingDigitsInWrongPosition(int number, int numberOfDigits) => ToIntArray(number).Select((d, i) => HasDigit(d) && !NthDigitIs(i + 1, d)).Count(t => t) == numberOfDigits;

        public bool OneMatchingDigitInCorrectPosition(int number) => MatchingDigitsInCorrectPosition(number, 1);

        public bool TwoMatchingDigitsInCorrectPosition(int number) => MatchingDigitsInCorrectPosition(number, 2);

        bool MatchingDigitsInCorrectPosition(int number, int numberOfDigits) => ToIntArray(number).Select((d, i) => NthDigitIs(i + 1, d)).Count(t => t) == numberOfDigits;
        public bool NthDigitIs(int nth, int d) => NthDigit(nth) == d;
        public int NthDigit(int nth) => int.Parse(s.Substring(nth - 1, 1));

        public bool HasDigit(int d) => s.Contains(d.ToString());

        public bool AllWrong(int number) => ToIntArray(number).All(d => !s.Contains(d.ToString()));

        public override string ToString() => s;
    }
}
