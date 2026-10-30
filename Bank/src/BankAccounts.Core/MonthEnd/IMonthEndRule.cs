using BankAccounts.Core.Accounts;
namespace BankAccounts.Core.MonthEnd;

// каждое правило - отд класс, новые правила добавляются без и зменения старых (OCP, SRP)
public interface IMonthEndRule
{
    void Apply(IAccountOperations account, DateTime asOf);
}
