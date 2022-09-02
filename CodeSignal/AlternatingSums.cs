using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeSignal
{
    [TestClass]
    public class AlternatingSums
    {
        [TestMethod]
        public void Test()
        {
            var balances = new int[] { 10, 100, 20, 50, 30 };
            var requests = new string[] { "withdraw 2 10", "transfer 5 1 20", "deposit 5 20", "transfer 3 4 15" };
            var jj = solution(balances, requests);
            //the output should be solution(balances, requests) = [30, 90, 5, 65, 30].
        }

        int[] solution(int[] balances, string[] requests)
        {
            var transactions = new System.Collections.Generic.Dictionary<string, System.Func<int[], int[], bool>>()
            {
                {"withdraw", withdraw },
                {"transfer", transfer },
                {"deposit", deposit }
            };
            for (var i = 0; i < requests.Length; i++)
            {
                var transaction = requests[i].Split(" ")[0];
                var parameters = requests[i].Split(" ").Skip(1).Select(i => int.Parse(i)).ToArray();
                var success = transactions[transaction](parameters, balances);
                if (!success) return new int[] { -(i + 1)};
            }
            return balances;
        }

        bool isValidAccountNr(int a, int[] balances)
        {
            return a >= 0 && balances.Length > a;
        }

        bool transfer(int[] parameters, int[] balances)
        {
            int fromAcc = parameters[0];
            if (!isValidAccountNr(fromAcc - 1, balances)) return false;
            int toAcc = parameters[1];
            if (!isValidAccountNr(toAcc - 1, balances)) return false;
            int sum = parameters[2];
            if (sum > balances[fromAcc - 1]) return false;
            balances[fromAcc - 1] -= sum;
            balances[toAcc - 1] += sum;
            return true;
        }

        bool withdraw(int[] parameters, int[] balances)
        {
            int fromAcc = parameters[0];
            if (!isValidAccountNr(fromAcc - 1, balances)) return false;
            int sum = parameters[1];
            if (sum > balances[fromAcc - 1]) return false;
            balances[fromAcc - 1] -= sum;
            return true;
        }

        bool deposit(int[] parameters, int[] balances)
        {
            int toAcc = parameters[0];
            if (!isValidAccountNr(toAcc - 1, balances)) return false;
            int sum = parameters[1];
            balances[toAcc - 1] += sum;
            return true;
        }
    }
}
