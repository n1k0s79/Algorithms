using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeWars
{
    [TestClass]
    public class ValidBracesKata
    {
        /*
        Write a function that takes a string of braces, and determines if the order of the braces is valid. It should return true if the string is valid, and false if it's invalid.

        This Kata is similar to the Valid Parentheses Kata, but introduces new characters: brackets [], and curly braces {}. Thanks to @arnedag for the idea!

        All input strings will be nonempty, and will only consist of parentheses, brackets and curly braces: ()[]{}.

        What is considered Valid?
        A string of braces is considered valid if all braces are matched with the correct brace.

        Examples
         */
        [TestMethod]
        public void Test()
        {
            Func<string, bool> ValidBraces = ValidBracesC;
            Assert.IsTrue(ValidBraces("()"));
            Assert.IsTrue(ValidBraces("[]"));
            Assert.IsTrue(ValidBraces("(){}[]"));
            Assert.IsTrue(ValidBraces("([{}])"));
            Assert.IsTrue(ValidBraces("([{}])"));
            Assert.IsFalse(ValidBraces("[(])"));
            Assert.IsTrue(ValidBraces("({})[({})]"));
            Assert.IsFalse(ValidBraces("(})"));
            Assert.IsTrue(ValidBraces("{}"));
            Assert.IsTrue(ValidBraces("(({{[[]]}}))"));
            Assert.IsTrue(ValidBraces("{}({})[]"));
            Assert.IsFalse(ValidBraces(")"));
            Assert.IsFalse(ValidBraces(")(}{][")); // αυτό το test case δεν το είχα σκεφτεί και η λύση μου αποτύγχανε
            Assert.IsFalse(ValidBraces("())({}}{()][]["));
            Assert.IsFalse(ValidBraces("(((({{"));
            Assert.IsFalse(ValidBraces("}}]]))}])"));
        }

        // Η δικιά μου λύση ήταν η εξής:
        // 1) διακρίνω τους τρεις τύπους αγκυλών
        // 2) φτιάχνω ένα λεξικό και δίπλα σε κάθε τύπο κρατώ τον αριθμό των "ανοιχτών" αγκύλων
        // 3) παίρνω έναν-έναν τους χαρακτήρες και ενημερώνω το λεξικό
        // 4) κοιτάζω σε κάθε βήμα αν το λεξικό είναι έγκυρο
        //    για να είναι έγκυρο θα πρέπει το πλήθος των ανοιχτών αγκυλών να είναι >=0 και επίσης δε θα πρέπει μια εσωτερική αγκύλη να κλείνει μετά από μία εξωτερική

        public static bool ValidBracesA(String braces)
        {
            var bracketTypes = new List<string>() { "()", "[]", "{}" };
            var openBracketTypes = new Dictionary<string, int>();
            foreach (var c in braces)
            {
                var bracketType = bracketTypes.Single(b => b.Contains(c));
                var opens = bracketType.IndexOf(c) == 0;
                if (!openBracketTypes.ContainsKey(bracketType)) openBracketTypes.Add(bracketType, 0);
                if (opens) openBracketTypes[bracketType]++; else openBracketTypes[bracketType]--;
                var stateValid = openBracketTypes.Values.All(v => v >= 0) && openBracketTypes.Values.OrderByDescending(v => v).SequenceEqual(openBracketTypes.Values);
                if (!stateValid) return false;
                if (openBracketTypes[bracketType] == 0) openBracketTypes.Remove(bracketType); // για να μπορέσει ένας άλλος τύπος παρένθεσης να γίνει "εξωτερικός"
            }
            return !openBracketTypes.Any();
        }

        // η βέλτιστη λύση θα ήταν να χρησιμοποιήσω στοίβα όπως εδώ
        // η λύση αυτή έχει τα εξής πλεονεκτήματα:
        // 1) είναι η πρώτη που θα σκεφτόταν κάποιος να υλοποιήσει (κάποιος άλλος εκτός από μένα, μάλλον λόγω του ότι δεν έχω χρησιμοποιήσει πολύ στοίβες παρά μόνο για να διατρέχω δέντρα)
        // 2) είναι απλή
        // 3) είναι εύκολο να την περιγράψεις και να την εξηγήσεις
        public static bool ValidBracesB(string braces)
        {
            var st = new Stack<char>();
            foreach (var c in braces)
                switch (c)
                {
                    case '(':
                    case '[':
                    case '{':
                        st.Push(c);
                        continue;
                    case ')':
                        if (st.Count == 0 || st.Pop() != '(') return false;
                        continue;
                    case ']':
                        if (st.Count == 0 || st.Pop() != '[') return false;
                        continue;
                    case '}':
                        if (st.Count == 0 || st.Pop() != '{') return false;
                        continue;
                }
            return st.Count == 0;
        }

        // λύση ενός άλλου τύπου στο CodeWars (πολύ έξυπνη)
        // αφαιρεί βήμα-βήμα όλα τα ζευγάρια των αγκυλών
        // για να σταματήσει την επανάληψη ελέγχει αν με την αφαίρεση προέκυψε όντως κάποια αλλαγή
        // τελειώνοντας θα πρέπει να έχω απομείνει με κενό string. Αν όχι τότε οι αγκύλες μου είναι λάθος
        public static bool ValidBracesC(string str)
        {
            var prev = string.Empty;
            while (str.Length != prev.Length)
            {
                prev = str;
                str = str
                    .Replace("()", string.Empty)
                    .Replace("[]", string.Empty)
                    .Replace("{}", string.Empty);
            }
            return str.Length == 0;
        }
    }
}
