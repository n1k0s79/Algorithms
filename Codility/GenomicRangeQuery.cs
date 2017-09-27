using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Codility
{
    class Solution
    {
        // προσπάθησα να παίξω με bitArray και μετά το άλλαξα σε bitwise operations
        // ήθελα να δω τι περιέχει η συμβολοσειρά μέχρι κάποιο σημείο
        // π.χ. αν ξέρω ότι στο σημείο 10 έχει έρθει το Α ενώ μέχρι το σημείο 5 δεν έχει έρθει 
        // τότε ξέρω ότι το Α έχει έρθει κάποια στιγμή από το σημείο 5 μέχρι το σημείο 10
        // έτσι ξέρω ότι το τμήμα 5-10 το περιέχει
        // Αυτό όμως δε με καλύπτει στην περίπτωση που ΚΑΙ μέχρι το σημείο 5 έχει έρθει το Α
        // Γιατί πώς θα ξέρω αν το περιέχει το 5-10;
        // Έτσι αποφάσισα να κρατήσω 4 πίνακες με prefix sum (έναν για κάθε γράμμα)
        public int[] solution(string S, int[] P, int[] Q)
        {
            var pA = GetPrefixSums(S, 'A');
            var pC = GetPrefixSums(S, 'C');
            var pG = GetPrefixSums(S, 'G');
            var pT = GetPrefixSums(S, 'T');

            var ret = new int[P.Length];
            for (int m = 0; m < P.Length; m++)
            {
                int p = P[m];
                int q = Q[m];
                int min = GetMin(pA, pC, pG, pT, p, q);
                ret[m] = min;
            }

            return ret;
        }

   
        private static int GetMin(int[] pA, int[] pC, int[] pG, int[] pT, int p, int q)
        {
            if (Contains(pA, p, q)) return 1;
            if (Contains(pC, p, q)) return 2;
            if (Contains(pG, p, q)) return 3;
            if (Contains(pT, p, q)) return 4;
            return 5;
        }

        private static string GetContainsByPrefix(int[] pA, int[] pC, int[] pG, int[] pT, int p, int q)
        {
            var ret = "";
            if (Contains(pA, p, q)) ret += "A";
            if (Contains(pC, p, q)) ret += "C";
            if (Contains(pG, p, q)) ret += "G";
            if (Contains(pT, p, q)) ret += "T";
            return ret;
        }

        private static bool Contains(int[] prefix, int p, int q)
        {
            int itemsContained = 0;
            int prev = 0;
            if (p - 1 >= 0) prev = prefix[p - 1];
            itemsContained = prefix[q] - prev;
            return itemsContained > 0;
        }
     
        private static int[] GetPrefixSums(string s, char c)
        {
            int sum = 0;
            var ret = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == c) sum++;
                ret[i] = sum;
            }

            return ret;
        }

        private static int GetMin(string s, int p, int q)
        {
            int n = s.Length;
            var k = s.Substring(p, q - p + 1);
            if (k.Contains("A")) return 1;
            if (k.Contains("C")) return 2;
            if (k.Contains("G")) return 3;
            if (k.Contains("T")) return 4;
            return 5;
        }
    }

    [TestClass]
    public class GenomicRangeQuery
    {   
     
        [TestMethod]
        public void TestSolution()
        {
            var s = new Solution();
            var g = GenerateSequence();
            int[] P;
            int[] Q;
            GenerateArrays(g, out P, out Q);
            s.solution(g, P, Q);
            //s.solution(g, new int[] { 5, 2, 5, 0 }, new int[] { 5, 4, 5, 6 });
        }

        const int SequenceLength = 1000;
        private static void GenerateArrays(string sequence, out int[] P, out int[] Q)
        {
            var l = new List<Tuple<int, int>>();
            for (int startIndex = 0; startIndex < sequence.Length - 1; startIndex++)
            {
                for (int length = 1; length < sequence.Length - startIndex + 1; length++)
                {
                    l.Add(new Tuple<int, int>(startIndex, startIndex + length - 1));
                }
            }

            l.Add(new Tuple<int, int>(sequence.Length - 1, sequence.Length - 1));

            P = new int[l.Count];
            Q = new int[l.Count];
            int i = 0;
            foreach(var t in l)
            {
                P[i] = t.Item1;
                Q[i] = t.Item2;
                i++;
            }
        }

        private static string GenerateSequence()
        {
            var ar = new char[SequenceLength];
            var rnd = new Random(DateTime.Now.Second);
            var chars = new char[] { 'A', 'C', 'G', 'T' };
            for (int i = 0; i < ar.Length; i++)
            {
                var r = rnd.Next(0, 4);
                var c = chars[r];
                ar[i] = c;
            }
            return new string(ar);
        }
    }
}