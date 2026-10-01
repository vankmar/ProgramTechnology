namespace Bank;

public class LineOfCreditAccount : BankAccount
{
    public LineOfCreditAccount(string name, decimal initialBalance)
        : base(name, initialBalance)
    {
    }

    public override void PerformMonthEndTransaction()
    {
        if (Balance > 0)
        {
            decimal interest = -Balance * 0.07m;
            MakeWithdrawal(interest, DateTime.UtcNow, "Charge monthly interest");
        }
    }
}
