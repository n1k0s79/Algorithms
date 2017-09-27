using System;

namespace Euler
{
    internal class Util
    {
        internal static double GetExecutionTime(Action act)
        {
            var s = System.Diagnostics.Stopwatch.StartNew();
            s.Start();
            act();
            s.Stop();
            return s.Elapsed.TotalMilliseconds;
        }
    }
}
