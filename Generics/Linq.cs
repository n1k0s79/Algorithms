namespace Generics
{
    [TestClass]
    public class Linq
    {
        delegate void SimpleDelegate();
        delegate int ComplexDelegate(int b, string c);
        Func<string, int> func;

        [TestMethod]
        public void FirstOrDefault()
        {
            var items = new List<int> { 1, 2, 3 };
            var item4 = items.FirstOrDefault(i => i == 4);

            SimpleDelegate u = () => { };
        }
    }
}