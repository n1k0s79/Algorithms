namespace Arrays
{
    public static class Extensions
    {
        public static void Rotate<T>(this T[] a, int rotations = 1, Rotator.Directions direction = Rotator.Directions.Left)
        {
            Rotator.Rotate(a, rotations, direction);
        }

        public static void Reverse<T>(this T[] a)
        {
            Util.Reverse(a);
        }

        public static void Reverse<T>(this T[] a, int start)
        {
            Util.Reverse(a, start);
        }

        public static void Reverse<T>(this T[] a, int start, int end)
        {
            Util.Reverse(a, start, end);
        }

        public static void SwapElements<T>(this T[] a, int i, int j)
        {
            Util.SwapElements(a, i, j);
        }

        public static string ToString<T>(this T[] a)
        {
            return Util.ArrayToString(a);
        }
    }
}