using System.Linq;

namespace Math
{
    // Note: System.Numerics.BigInteger is much faster
    public class BigInt
    {
        public readonly string Value;

        public BigInt()
        {
            Value = "0";
        }

        public BigInt(int a)
        {
            Value = a.ToString();
        }

        public BigInt(string s)
        {
            Value = s;
        }

        public int GetDigitFromRight(int index)
        {
            var r = Value.ToList();
            r.Reverse();
            if (index > r.Count) return 0;
            return int.Parse(r[index - 1].ToString());
        }

        public override string ToString()
        {
            return Value;
        }

        public long GetSumOfAllDigits()
        {
            long sum = 0;
            foreach (var i in DigitsArray) sum += i;
            return sum;
        }

        public int[] DigitsArray
        {
            get
            {
                var ret = new int[Value.Length];
                for(int i=0; i<Value.Length; i++)
                {
                    var c = Value[i];
                    ret[i] = int.Parse(c.ToString());
                }
                return ret;
            }
        }

        public static BigInt operator +(BigInt left, BigInt right)
        {
            string ret = string.Empty;
            int maxDigits = System.Math.Max(left.Value.Length, right.Value.Length);
            int carry = 0;
            for (int i = 1; i <= maxDigits; i++)
            {
                var sum = left.GetDigitFromRight(i) + right.GetDigitFromRight(i) + carry;
                int remainder = sum % 10;
                carry = (sum - remainder) / 10;
                ret = remainder + ret;
            }
            if (carry > 0) ret = carry + ret;

            return new BigInt(ret);
        }

        public static BigInt operator *(BigInt top, int n)
        {
            string ret = string.Empty;
            int carry = 0;
            for (int i = 1; i <= top.Value.Length; i++)
            {
                var prod = top.GetDigitFromRight(i) * n + carry;
                int remainder = prod % 10;
                carry = (prod - remainder) / 10;
                ret = remainder + ret;
            }
            if (carry > 0) ret = carry + ret;

            return new BigInt(ret);
        }
    }
}