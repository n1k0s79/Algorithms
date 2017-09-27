using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Strings
{
    public static class Extensions
    {
        public static IEnumerable<string> GetBetween(this string s, string from, string to)
        {
            string regx = string.Format("{0}0+{1}", from, to);
            var pattern = new Regex(regx);
            var groups = pattern.Match(s).Groups;
            
            foreach (var g in groups)
            {
                
            }
            //string input = "super exemple of string key : text I want to keep - end of my string";
            //var match = Regex.Match(input, @"key : (.+?)-").Groups[1].Value;
            return new List<string>();

            //        var groups = Regex.Match(s, string.Format("key {0} (.*) {1}", from, to);
            //    "super exemple of string key : text I want to keep - end of my string",
            //    "key : (.*) - ")
            //.Groups[1].Value;
        }
    }
}
