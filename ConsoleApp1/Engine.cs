namespace ConsoleApp1
{
    public class Engine
    {
        private bool Functional;
        public event EventHandler<string> StateChanged;

        public Engine()
        {
        }

        private void Test()
        {
            StateChanged.Invoke(this, "Broken");
        }
    }
}
