namespace Bank; // это по новому синтаксису 

/// <summary>
/// класс подарочной карты, унаследованный от класса банковского аккаунта
/// </summary>
public class GiftCardAccount : BankAccount
{
    private readonly decimal _monthlyDeposit = 0m; // параметр по умолч

    // monthlyDeposit  по умолч 0, при созд объекта нью гифтк.. на 1 месте перед. имя, нач. бал., по ум. мД = 0, при задании = заданному

    /// <summary>
    /// конструктор объекта класса подарочной карты
    /// </summary>
    /// <param name="name"> имя владельца </param>
    /// <param name="initialBalance"> изначальный баланс </param>
    /// <param name="monthlyDeposit"> ежемесячно начисляемая сумма </param>
    public GiftCardAccount(string name, decimal initialBalance, decimal monthlyDeposit)
        // : base(name, initialBalance => _monthlyDeposit = monthlyDeposit; // нов синтаксис
        : base(name, initialBalance)
    {
        _monthlyDeposit = monthlyDeposit;
    }

    /// <summary>
    /// метод Совершить транзакцию в конце месяца для класса подарочной карты
    /// </summary>
    public override void PerformMonthEndTransaction()
    {
        if (_monthlyDeposit != 0)
        {
            Transaction? interest = new(_monthlyDeposit, DateTime.UtcNow, "Apply bonus");

            _allTransations.Add(interest);
            _interestLogs.Log(Number, "Interest", _monthlyDeposit);
        }
            //MakeDeposit(_monthlyDeposit, DateTime.UtcNow, "Add monthly interest");
    }

    /// <summary>
    /// переопределённый метод В Строку для класса подарочной карты
    /// </summary>
    /// <returns> возвращает строку </returns>
    public override string ToString()
    {
        return base.ToString() + $"monthly deposit : {_monthlyDeposit}";
    }
}
