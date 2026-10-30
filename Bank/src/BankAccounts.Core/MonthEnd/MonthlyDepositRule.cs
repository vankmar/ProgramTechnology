using BankAccounts.Core.Accounts;
namespace BankAccounts.Core.MonthEnd;

// ежемесячное пополнение для подарочной карты
public class MonthlyDepositRule : IMonthEndRule
{
    private readonly decimal _amount;
    public MonthlyDepositRule(decimal amount)
    {
        _amount = amount;
    }
    public void Apply(IAccountOperations account, DateTime asOf)
    {
        if(_amount != 0)
            account.Deposit(_amount, asOf, "add monhly deposit");
    }
}
