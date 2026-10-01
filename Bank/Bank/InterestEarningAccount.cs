namespace Bank;

public class InterestEarningAccount : BankAccount
{
    public InterestEarningAccount(string name, decimal initialBalance)
        : base(name, initialBalance)
    {
    }

    // override позв в доч классе опр новую реализ метода PerformMonthEndTransaction
    public override void PerformMonthEndTransaction() 
    {
        if (Balance > 500m) // 500m - 500 децимал
        {
            decimal interest = Balance * 0.02m;
            MakeDeposit(interest, DateTime.UtcNow, "Apply month interest");
        }

    }

}
