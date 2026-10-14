namespace Bank;

/// <summary>
/// класс накопительного счёта, унаследованный от класса банковского аккаунта
/// </summary>
public class InterestEarningAccount : BankAccount
{

    /// <summary>
    ///  конструктор объекта класса накопительного счёта
    /// </summary>
    /// <param name="name"> имя владельца </param>
    /// <param name="initialBalance"> изначальный баланс </param>
    public InterestEarningAccount(string name, decimal initialBalance)
        : base(name, initialBalance)
    {
    }

    // override позв в доч классе опр новую реализ метода PerformMonthEndTransaction
    /// <summary>
    /// метод Совершить транзакцию в конце месяца для класса накопительного счёта
    /// если баланс больше 500 начисляется процент 2%
    /// </summary>
    public override void PerformMonthEndTransaction() 
    {
        if (Balance > 500m) // 500m - 500 децимал
        {
            decimal interest = Balance * 0.02m;

            Transaction? interestTr = new(interest, DateTime.UtcNow, "Apply month interest");

            _allTransations.Add(interestTr);
            _interestLogs.Log(Number, "Interest", interest);
            // MakeDeposit(interest, DateTime.UtcNow, "Apply month interest");
        }
    }
}
