using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runner
{
    internal class ConsoleUtils
    {
        internal static int ReadInteger()
        {
            return Convert.ToInt32(Console.ReadLine());
        }

        internal static int[] ReadIntegers()
        {
            string line = Console.ReadLine();
            if (string.IsNullOrEmpty(line)) return null;

            string[] stringArray = line.Split(' ');
            return Array.ConvertAll(stringArray, Int32.Parse);
        }
    }
}
