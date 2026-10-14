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

            InterestEarningAccount interest = new InterestEarningAccount("Yana", 1000m);
            Console.WriteLine(interest.GetAccountHistory());

            Console.WriteLine();

            LineOfCreditAccount lineOfCreditAccount = new LineOfCreditAccount("Yana", 0m, 1000m);
            lineOfCreditAccount.MakeWithdrawal(500m, DateTime.UtcNow, "credit");


            GiftCardAccount giftCard = new GiftCardAccount("Yana", 1000m, 5000m);

            lineOfCreditAccount.MakeWithdrawal(10000m, DateTime.UtcNow, "credit");



            List<BankAccount> accounts = new List<BankAccount>(); // об. баз. класса
            accounts.Add(account1);
            accounts.Add(giftCard);
            accounts.Add(interest); // объекты дочерних
            accounts.Add(lineOfCreditAccount); // классов

            foreach (BankAccount account in accounts)
            {
                Console.WriteLine(account);
                account.PerformMonthEndTransaction(); // такой вызыватся в зависимости из какого класса акк
                Console.WriteLine(account.GetAccountHistory());
            }


            // тест задачи 1

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Тест 1");


            account1.ChangeAccountStatus(BankAccount.AccountStatus.Premium);
            account1.PerformMonthEndTransaction();
            Console.WriteLine(account1.GetAccountHistory()); // один раз выведется комиссия тк раньше был регюлар и исп-ся PerformMonthEndTransaction на нём  

            account2.ChangeAccountStatus(BankAccount.AccountStatus.VIP);
            account2.MakeDeposit(1000000000, DateTime.UtcNow, "");

            account2.MakeWithdrawal(10000000, DateTime.UtcNow, ":(");
            account2.MakeWithdrawal(10000, DateTime.UtcNow, ":(");
            account2.PerformMonthEndTransaction();
            Console.WriteLine(account2.GetAccountHistory());

            // тест задачи 2
            Console.WriteLine("Тест 2");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();


            account2.ShowDepositLogs();
            Console.WriteLine();
            account2.ShowWithdrawalLogs();
            Console.WriteLine();
            account2.ShowInterestLogs();

            // тест задачи 3
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Тест 3");
            account1.MakeDeposit(10000, DateTime.UtcNow, "");
            var transfer = new TransferService();
            try
            {
                transfer.Transfer(account1, account2, 200m);
                Console.WriteLine("Перевод выполнен успешно.");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Ошибка перевода: {e.Message}");
            }

            Console.WriteLine(account1.GetAccountHistory());
            Console.WriteLine();
            Console.WriteLine(account2.GetAccountHistory());
        }
    }
}

