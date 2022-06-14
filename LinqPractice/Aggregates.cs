using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqPractice
{
    [TestClass]
    public class Aggregates
    {
        /// <summary>
        /// H πρώτη και απλούστερη Aggregate τρέχει Ν-1 φορές για Ν στοιχεία
        /// - Την πρώτη φορά θα περάσει το 1ο και το 2ο στοιχείο στις μεταβητές α και β αντίστοιχα
        /// - τη 2η φορά θα πάρει στη μεταβλητή α το αποτέλεσμα της 1ης εκτέλεσης και στη μεταβλητή β το 3ο στοιχείο 
        /// - τη Χη φορά (όπου Χ > 1) θα πάρει στη μεταβλητή α το αποτέλεσμα της εκτέλεσης Χ-1 και στη μεταβλητή β το στοιχείο Ν+1
        /// </summary>
        [TestMethod]
        public void SimpleAggregate()
        {
            var seq = new int[] { 1, 2, 3, 4, 5 };
            var iterations = string.Empty;
            var i = 1;
            var g = seq.Aggregate((a, b) => 
            {
                var ret = a + b;
                iterations += $"iteration:{i}, a={a}, b={b}, ret={ret}{System.Environment.NewLine}";
                i++;
                return a + b;
            });
            Assert.AreEqual(15, g);
            var expectedIterations = @"
iteration:1, a=1, b=2, ret=3
iteration:2, a=3, b=3, ret=6
iteration:3, a=6, b=4, ret=10
iteration:4, a=10, b=5, ret=15";
            Assert.AreEqual(expectedIterations.Trim(), iterations.Trim());
        }

        /// <summary>
        /// H δεύτερη Aggregate (με μετασχηματισμό) τρέχει Ν φορές για Ν στοιχεία
        /// - το προϊόν του μετασχηματισμού στο βήμα Χ τροφοδοτείται στο βήμα Χ+1
        /// - για το πρώτο βήμα χρησιμοποιείται ο "σπόρος" seed γι' αυτό και η συγκεκριμένη Aggregate παίρνει δύο ορίσματα
        /// (το πρώτο είναι ο σπόρος)
        /// </summary>
        [TestMethod]
        public void AggregateWithTransformation()
        {
            var seq = new int[] { 1, 2, 3, 4, 5 };
            var iterations = string.Empty;
            var i = 1;
            var result = seq.Aggregate(string.Empty, (conc, item) =>
            {
                var ret = conc + item.ToString();
                iterations += $"iteration:{i}, acc={conc}, item={item}, ret={ret}{System.Environment.NewLine}";
                i++;
                return conc + item.ToString();
            });
            Assert.AreEqual("12345", result);
            var expectedIterations = @"
iteration:1, acc=, item=1, ret=1
iteration:2, acc=1, item=2, ret=12
iteration:3, acc=12, item=3, ret=123
iteration:4, acc=123, item=4, ret=1234
iteration:5, acc=1234, item=5, ret=12345";
            Assert.AreEqual(expectedIterations.Trim(), iterations.Trim());
        }

        /// <summary>
        /// Η τελευταία υπερφόρτωση της Aggregate είναι μάλλον άχρηστη. Μιας και η 2η συνάρτηση που παίρνει ως όρισμα τρέχει μία φορά στο τέλος.
        /// Είναι δηλαδή το ίδιο με το αν το έτρεχα εκτός του Aggregate.
        /// </summary>
        [TestMethod]
        public void AggregateLast()
        {
            var seq = new int[] { 1, 2, 3, 4, 5 };
            var iterations = string.Empty;
            var resultSelectorIterations = string.Empty;
            var i = 1;
            var r = 1;
            var result = seq.Aggregate(string.Empty, (conc, item) =>
            {
                var ret = conc + item.ToString();
                iterations += $"iteration:{i}, acc={conc}, item={item}, ret={ret}{System.Environment.NewLine}";
                i++;
                return conc + item.ToString();
            }, a =>
            {
                resultSelectorIterations += r + System.Environment.NewLine;
                return a.Length;
            });
            Assert.AreEqual(5, result);
            var expectedIterations = @"
iteration:1, acc=, item=1, ret=1
iteration:2, acc=1, item=2, ret=12
iteration:3, acc=12, item=3, ret=123
iteration:4, acc=123, item=4, ret=1234
iteration:5, acc=1234, item=5, ret=12345";
            Assert.AreEqual(expectedIterations.Trim(), iterations.Trim());
            Assert.AreEqual("1", resultSelectorIterations.Trim());
        }
    }
}
