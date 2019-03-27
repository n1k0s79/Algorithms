using System;
using System.Data.SqlClient;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = Stelios.MultiplicationValidator.Validate(87652892, 982345);

            const int max = 1000;
            long counter = 0;
            long total = max * max;

            for(int a = 1; a < max; a++)
                for (int b = 1; b < max; b++)
                {
                    counter++;
                    var percent = (double)counter / (double)total * (double)100;
                    var v = Stelios.MultiplicationValidator.Validate(a, b);
                    if (!v) throw new Exception(a.ToString() + "," + b.ToString());
                }
        }
    }
}