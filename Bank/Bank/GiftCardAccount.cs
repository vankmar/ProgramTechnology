namespace Bank; // это по новому синтаксису 

public class GiftCardAccount : BankAccount
{
    private readonly decimal _monthlyDeposit = 0m; // параметр по умолч

    // monthlyDeposit  по умолч 0, при созд объекта нью гифтк.. на 1 месте перед. имя, нач. бал., по ум. мД = 0, при задании = заданному
    public GiftCardAccount(string name, decimal initialBalance, decimal monthlyDeposit)
        // : base(name, initialBalance => _monthlyDeposit = monthlyDeposit; // нов синтаксис
        : base(name, initialBalance)
    {
        _monthlyDeposit = monthlyDeposit;
    }

    public override void PerformMonthEndTransaction()
    {
        if (_monthlyDeposit != 0)
            MakeDeposit(_monthlyDeposit, DateTime.UtcNow, "Add monthly interest");
    }

    public override string ToString()
    {
        return base.ToString() + $"monthly deposit : {_monthlyDeposit}";
    }
}
