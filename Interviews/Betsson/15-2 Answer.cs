/*
 * Αν τρέξω μία async μέθοδο χωρίς await τότε αυτή θα επιστρέψει ένα Task και όχι το αποτέλεσμα της εκτέλεσης του Task.
 * Επίσης το Task δε θα τρέξει
 */
namespace Interviews.Betsson.Question15
{
    /*
     * 
    greenfield vs brownfield
    ----------------------------------------
    What is difference between greenfield and brownfield?
    Greenfield and brownfield investments are two types of foreign direct investment.
    With greenfield investing, a company will build its own, brand new facilities from the ground up.
    Brownfield investment happens when a company purchases or leases an existing facility.
    */

    class Customer
    {

    }

    [TestClass]
    public class Question15
    {
        async Task<int> TestMethod()
        {
            var b = 1;
            await Task.Run(() =>
            {
                b = 2;
            });
            return b;
        }

        [TestMethod] 
        public async Task Test()
        {
            //var r1 = await TestMethod();
            //Assert.IsInstanceOfType(r1, typeof(int));
            var r2 = TestMethod();
            Assert.IsInstanceOfType(r2, typeof(Task));
            var j = r2.Result;
        }
    }
}
