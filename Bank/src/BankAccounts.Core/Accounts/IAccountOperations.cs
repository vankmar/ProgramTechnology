namespace BankAccounts.Core.Accounts;

// 
public interface IAccountOperations
{
    decimal Balance { get; }
    void Deposit(decimal amount3, DateTime data, string note);
    void Withdraw(decimal amount3, DateTime data, string note);
}
