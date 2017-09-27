using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Euler
{
    //Names scores
    //Problem 22
    // Using names.txt(right click and 'Save Link/Target As...'), a 46K text file containing over five-thousand first names, 
    // begin by sorting it into alphabetical order.Then working out the alphabetical value for each name, 
    // multiply this value by its alphabetical position in the list to obtain a name score.
    // For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. 
    // So, COLIN would obtain a score of 938 × 53 = 49714.
    // What is the total of all the name scores in the file?

    [TestClass]
    public class Problem022_Names_scores
    {
        [TestMethod]
        public void Test()
        {            
            Assert.AreEqual(870821383, solution());
        }

        public long solution()
        {
            var s = System.IO.File.ReadAllText(@"c:\temp\p022_names.txt");
            var st = new System.IO.StreamWriter(@"c:\temp\test.txt");
            s = s.Replace("\"", "");
            var names = new List<string>(s.Split(','));
            names.Sort();
            long sum = 0;
            checked
            {                
                for (int i = 0; i < names.Count; i++)           // ****** Stupid mistake: I iterated while < Count - 1, instead of < Count
                {
                    string name = names[i];
                    int c = GetStringScore(name);
                    int score = (i + 1) * c;
                    string line = string.Format("{0} {1} {2} {3}", (i + 1).ToString().PadLeft(4), name.PadRight(30), c.ToString().PadRight(10), score);
                    st.WriteLine(line);
                    sum += score;
                }
            }

            st.Close();
            var keys = new List<char>(dict.Keys);
            keys.Sort();
            var d = new Dictionary<char, int>();
            foreach (var k in keys)
            {
                d.Add(k, dict[k]);
            }

            return sum;
        }

        private static int GetStringScore(string s)
        {
            int sum = 0;
            foreach (var c in s.ToUpper()) sum += LetterNr(c);
            return sum;
        }

        private static Dictionary<char, int> dict = new Dictionary<char, int>();
        private static int LetterNr(char c)
        {
            dict[c] = c - 64;
            return c - 64;
        }
    }
}