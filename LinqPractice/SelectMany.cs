using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqPractice
{
    [TestClass]
    public class SelectMany
    {
        /// <summary>
        /// H πρώτη μορφή της SelectMany εφαρμόζεται πάνω σε μία ακολουθία και παίρνει μία συνάρτηση μετασχηματισμού 
        /// Η συνάρτηση μετασχηματισμού παράγει μια άλλη ακολουθία για κάθε ένα στοιχείο της αρχικής ακολουθίας
        /// Το ενδιάμεσο αποτέλεσμα είναι μία ακολουθία από ακολουθίες.
        /// Τέλος επιπεδοποιεί τις ακολουθίες σε μία
        /// Το πλήθος των στοιχείων της τελικής ακολουθίας είναι Μ1 + Μ2 + ... + Μν
        ///    όπου Μν είναι το πλήθος των στοιχείων της ακολουθίας που παρήχθησε από το στοιχείο ν της αρχικής ακολουθίας
        /// </summary>
        [TestMethod]
        public void SelectMany1()
        {
            var a = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var result = a.SelectMany(i => new char[] { i, i, i }).ToList();
            var expected = new char[] { 'a', 'a', 'a',     'b', 'b', 'b',     'c', 'c', 'c',     'd', 'd', 'd',     'e', 'e', 'e' };
            Assert.IsTrue(expected.SequenceEqual(result));
            Assert.AreEqual(15, result.Count);
        }

        /// <summary>
        /// H δεύτερη μορφή της SelectMany εφαρμόζεται πάνω σε μία ακολουθία και παίρνει μία συνάρτηση μετασχηματισμού 
        /// Η συνάρτηση μετασχηματισμού παράγει μια άλλη ακολουθία λαμβάνοντας το κάθε στοιχείο της αρχικής ακολουθίας μαζί με το δείκτη του
        /// Το ενδιάμεσο αποτέλεσμα είναι μία ακολουθία από ακολουθίες.
        /// Τέλος επιπεδοποιεί τις ακολουθίες σε μία
        /// Το πλήθος των στοιχείων της τελικής ακολουθίας είναι Μ1 + Μ2 + ... + Μν
        ///    όπου Μν είναι το πλήθος των στοιχείων της ακολουθίας που παρήχθησε από το στοιχείο ν της αρχικής ακολουθίας
        /// </summary>
        [TestMethod]
        public void SelectMany2()
        {
            var a = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var result = a.SelectMany((item, index) => new string[] { item.ToString(), index.ToString() }).ToList();
            var expected = new string[] { "a", "0",
                                          "b", "1", 
                                          "c", "2", 
                                          "d", "3",
                                          "e", "4" };
            Assert.IsTrue(expected.SequenceEqual(result));
            Assert.AreEqual(10, result.Count);
        }

        /// <summary>
        /// H τρίτη μορφή της SelectMany εφαρμόζεται πάνω σε μία ακολουθία και παίρνει δύο συναρτήσεις:
        /// - μία συνάρτηση μετασχηματισμού η οποία παράγει μία άλλη ακολουθία για κάθε ένα στοιχείο της αρχικής ακολουθίας
        /// - μία συνάρτηση μετασχηματισμού η οποία λαμβάνει δύο ορίσματα:
        ///   α) το κάθε στοιχείο της πρώτης ακολουθίας
        ///   β) το κάθε στοιχείο της παραχθείσας (από την πρώτη συνάρτηση μετασχηματισμού) ακολουθίας
        /// Το πλήθος των στοιχείων της τελικής ακολουθίας είναι Μ1 + Μ2 + ... + Μν
        ///    όπου Μν είναι το πλήθος των στοιχείων της ακολουθίας που παρήχθησε από το στοιχείο ν της αρχικής ακολουθίας
        /// </summary>
        [TestMethod]
        public void SelectMany3()
        {
            var a = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var result = a.SelectMany(c => new string[] { c.ToString().ToUpper(), ((int)c).ToString()}, (c, i) => c.ToString() + i.ToString()).ToList();
            Assert.IsTrue(new string[] { "aA", "a97", "bB", "b98", "cC", "c99", "dD", "d100", "eE", "e101" }.SequenceEqual(result));
            Assert.AreEqual(10, result.Count);
        }
    }
}
