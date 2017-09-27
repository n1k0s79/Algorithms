using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    public class Generator
    {
        public static int[] Generate(int length, int min = int.MinValue, int max = int.MaxValue)
        {
            var r = new Random(DateTime.Now.Second);
            var ret = new int[length];
            for(int i = 0;i < ret.Length; i++) ret[i] = r.Next(min, max);

            return ret;
        }
    }
}
