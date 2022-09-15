namespace Util
{
    public class Timer
    {
        public static long Measure(Action action, int repetitions)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            for (int i = 0; i < repetitions; i++) action();
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
    }
}