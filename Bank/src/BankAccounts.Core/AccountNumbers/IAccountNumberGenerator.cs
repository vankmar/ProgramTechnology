namespace BankAccounts.Core.AccountNumbers;

// отд ответственность, не должна быть внутри счёта
public interface IAccountNumberGenerator
{
    public string Next();
}