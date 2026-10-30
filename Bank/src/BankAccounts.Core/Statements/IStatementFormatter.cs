using BankAccounts.Core.Transactions;
namespace BankAccounts.Core.Statements;

// форматирование - отдельная ответственность
// можно добавить JSON/CSV без правки счёта (SRP)
public interface IStatementFormatter
{
    string Format(IEnumerable<Transaction> transactions);
}
