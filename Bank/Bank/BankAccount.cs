using System.Text;

namespace Bank;

internal class BankAccount
{
    private List<Transaction> _allTransations = new List<Transaction>();
    public string Owner { get; private set; }
    public string Number { get; }
    public decimal Balance //decimal - очень точно, для фин оп
    { 
        get                
        {                  
            decimal balance = 0;
            foreach (var transaction in _allTransations)
                balance += transaction.Amount;
            return balance;
        }                  

    } 

    private static int s_accountNumberSeed = 1000000000; // стаtик - это поле прин всем методам класса ( и 1 и 2 им доступ)
    public BankAccount(string name, decimal initialBalance)
    {
        //this.Balance = initialBalance; // нужно если initialBalance и Balance имеют 1 имя
        //Balance = initialBalance;
        MakeDeposit(initialBalance, DateTime.UtcNow, "initial balance");
        Owner = name;
        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;
    }

    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0) throw new ArgumentOutOfRangeException (nameof(amount), "Amount of deposit must be positive");
        var deposit = new Transaction(amount, date, note);
        _allTransations.Add(deposit);
    }
    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        if (amount > Balance) throw new InvalidOperationException("Insufficient balance for this withdrawal");
        var withdrawal = new Transaction(-amount, date, note);
        _allTransations.Add(withdrawal);
    }

    public string GetAccountHistory()
    {
        var report = new StringBuilder();
        decimal balance = 0;
        report.AppendLine("Data\t\tAmount\tBalance\tNote");
        foreach (var item in _allTransations)
        {
            balance += item.Amount;
            report.AppendLine($"{item.Date.ToShortDateString}\t\t{item.Amount}\t{balance}\t{item.Note}");
        }
        return report.ToString();
    }
}

