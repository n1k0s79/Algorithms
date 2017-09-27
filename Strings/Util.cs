using System;
using System.Collections.Generic;

namespace Strings
{
    public class Util
    {
        public static List<string> SplitCamelCase(string s)
        {                
            // Strategy:
            // Maintain a previous index (0 at first) while iterating all characters of the string
            // If I step on an uppercase character extract the string from the previous index to the current index and set the previous index value to the current value
            // Do not forget to extract the last string

            var ret = new List<string>();
            if (string.IsNullOrEmpty(s)) return ret;

            int prevUpper = 0;
            for (int i = 1; i < s.Length; i++)            
            {
                if (Char.IsUpper(s[i]))
                {
                    ret.Add(s.Substring(prevUpper, i - prevUpper));
                    prevUpper = i;
                }
            }
            ret.Add(s.Substring(prevUpper));
            return ret;
        }
    }
}
