namespace Bank
{

    internal class Program
    {
        static void Main(string[] args)
        {

            BankAccount account1 = new BankAccount("Marina", 1000000000);
            BankAccount account2 = new BankAccount("Liza", 1000);

            Console.WriteLine($"{account1.Owner} {account1.Balance} {account1.Number}");
            Console.WriteLine($"{account2.Owner} {account2.Balance} {account2.Number}");

            account1.MakeDeposit(6767, DateTime.UtcNow, ":)");
            Console.WriteLine($"Balance: {account1.Balance}");
            account1.MakeWithdrawal(10000, DateTime.UtcNow, ":(");
            Console.WriteLine($"Balance: {account1.Balance}");

            Console.WriteLine(account1.GetAccountHistory());

            try
            {
                account2.MakeWithdrawal(10000000, DateTime.UtcNow, ":(");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            InterestEarningAccount interest = new InterestEarningAccount("Yana", 1000);
            interest.PerformMonthEndTransaction();
            Console.WriteLine(interest.GetAccountHistory());

            Console.WriteLine();

            LineOfCreditAccount lineOfCreditAccount = new LineOfCreditAccount("Yana", 10); // potom nazad 0

            List<BankAccount> accounts = new List<BankAccount>(); // об. баз. класса
            accounts.Add(account1);
            accounts.Add(interest); // объекты дочерних
            // accounts.Add(lineOfCreditAccount); // классов

            foreach (BankAccount account in accounts)
            {
                account.PerformMonthEndTransaction(); // такой вызыватся в зависимости из какого класса акк
                Console.WriteLine(account.GetAccountHistory());
            }


        }
    }
}

