namespace Bank;

public class LineOfCreditAccount : BankAccount
{
    public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit)
        : base(name, initialBalance, -creditLimit)
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

    protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn)
        => isOverdrawn ? new Transaction(-20, DateTime.UtcNow, "apply overdraft") : default;

    //protected override Transaction? CheckWithdrawalLimit(bool overdrawn)
    //{
    //    return isOverdrawn ? new Transaction(-20, DateTime.UtcNow, "apply overdraft") : default;
    //}
        
    //{
    //    return base.CheckWithdrawalLimit(overdrawn);
    //}
}
