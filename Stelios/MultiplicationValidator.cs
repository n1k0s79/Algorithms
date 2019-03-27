namespace Stelios
{
    public class MultiplicationValidator
    {
        public static bool Validate(long a, long b)
        {
            var c = checked(a * b);
            var t1 = Reduce(a);
            var t2 = Reduce(b);
            var t3 = Reduce(t1 * t2);
            var t4 = Reduce(c);
            return t3 == t4;
        }

        private static int Reduce(long a)
        {
            while (a > 9)
            {
                long total = 0;
                foreach(var c in a.ToString()) total += int.Parse(c.ToString());
                a = total;
            }

            return (int)a;
        }
    }
}
