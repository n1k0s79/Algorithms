using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeWars
{
    [TestClass]
    public class WhereMyAnagramsAt
    {
        /*
        What is an anagram? Well, two words are anagrams of each other if they both contain the same letters. For example:

        'abba' & 'baab' == true

        'abba' & 'bbaa' == true

        'abba' & 'abbba' == false

        'abba' & 'abca' == false
        Write a function that will find all the anagrams of a word from a list. You will be given two inputs a word and an array with words. You should return an array of all the anagrams or an empty array if there are none. For example:

        anagrams('abba', ['aabb', 'abcd', 'bbaa', 'dada']) => ['aabb', 'bbaa']

        anagrams('racer', ['crazer', 'carer', 'racar', 'caers', 'racer']) => ['carer', 'racer']

        anagrams('laser', ['lazing', 'lazy',  'lacer']) => []
        Note for Go
        For Go: Empty string slice is expected when there are no anagrams found.         
        */
        [TestMethod]
        public void Test()
        {
            var a = AnagramsAlt("abba", new List<string> { "aabb", "abcd", "bbaa", "dada" });
            var b = AnagramsAlt("racer", new List<string> { "crazer", "carer", "racar", "caers", "racer" });
            var c = AnagramsAlt("laser", new List<string> { "lazing", "lazy", "lacer" });
        }

        public static List<string> Anagrams(string word, List<string> words)
        {
            var signature = GetWordSignature(word);
            return words.Where(w => GetWordSignature(w) == signature).ToList();
        }

        private static string GetWordSignature(string word) => string.Join(string.Empty, word.ToCharArray().OrderBy(c => c).GroupBy(c => c).Select(g => $"{g.Key}{g.Count()}"));

        // έμαθα μία καινούρια Linq συνάρτηση! την SequenceEqual
        public static List<string> AnagramsAlt(string word, List<string> words) => words.Where(w => w.OrderBy(c => c).SequenceEqual(word.OrderBy(c => c))).ToList();
    }
}
