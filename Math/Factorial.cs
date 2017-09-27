namespace Math
{
    public class Factorial
    {
        public static long Calculate(int n)
        {
            long ret = 1;
            for(int i=1; i<=n; i++)
            {
                ret *= i;
            }
            return ret;
        }
    }
}