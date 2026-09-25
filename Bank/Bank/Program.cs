namespace Bank
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            // 
            BankAccount account1 = new BankAccount("Marina", 1000000000);
            BankAccount account2 = new BankAccount("Liza", 1000);

            Console.WriteLine($"{account1.Owner} {account1.Balance} {account1.Number}");
            Console.WriteLine($"{account2.Owner} {account2.Balance} {account2.Number}");

            account1.MakeDeposit(6767, DateTime.UtcNow, ":)");
            Console.WriteLine($"Balance: {account1.Balance}");
            account1.MakeWithdrawal(10000, DateTime.UtcNow, ":(");
            Console.WriteLine($"Balance: {account1.Balance}");

            try
            {
                account2.MakeWithdrawal(10000000, DateTime.UtcNow, ":(");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}


