namespace Math
{
    public class TriangleNumber
    {
        public readonly ulong value;

        public TriangleNumber(int n)
        {
            this.value = (ulong)n * ((ulong)n + 1) / 2;
        }
    }
}