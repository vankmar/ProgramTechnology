using BankAccounts.Core.Accounts;
namespace BankAccounts.Core.MonthEnd;

// проценты на долг (для линии кредита)
public class InterestOnNegativeBalanceRule : IMonthEndRule
{
    private readonly decimal _rate;
    public InterestOnNegativeBalanceRule(decimal rate)
    {
        _rate = rate;
    }
    public void Apply(IAccountOperations account, DateTime asOf)
    {
        if(account.Balance < 0)
            account.Withdraw(-account.Balance * _rate, asOf, "charge monthly interest");
    }
}
