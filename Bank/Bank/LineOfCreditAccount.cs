namespace Bank;

/// <summary>
/// класс кредитного счёта, унаследованный от класса банковского аккаунта
/// </summary>
public class LineOfCreditAccount : BankAccount
{
    /// <summary>
    /// конструктор объекта класса кредитного счёта
    /// </summary>
    /// <param name="name"> имя владельца </param>
    /// <param name="initialBalance"> изначальный баланс </param>
    /// <param name="creditLimit"> лимит кредита </param>
    public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit)
        : base(name, initialBalance, -creditLimit)
    {
    }

    /// <summary>
    /// метод Совершить транзакцию в конце месяца для класса кредитного счёта 
    /// </summary>
    public override void PerformMonthEndTransaction()
    {
        if (Balance > 0)
        {
            decimal interest = -Balance * 0.07m;

            Transaction? interestTr = new(interest, DateTime.UtcNow, "Charge monthly interest");

            _allTransations.Add(interestTr);
            _interestLogs.Log(Number, "Interest", interest);
            // MakeWithdrawal(interest, DateTime.UtcNow, "Charge monthly interest");
        }
    }

    /// <summary>
    ///  Проверка на овердрафт
    /// </summary>
    /// <param name="isOverdrawn"> булевое значение, был ли овердрафт </param>
    /// <returns> возвращает штрафную транзацию </returns>
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
