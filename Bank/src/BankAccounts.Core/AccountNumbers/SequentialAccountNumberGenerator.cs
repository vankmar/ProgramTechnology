namespace BankAccounts.Core.AccountNumbers;

// простая послед нумерация. можно заменить на гуид или др стратегию (srp)
public sealed class SequentialAccountNumberGenerator : IAccountNumberGenerator
{
    private int _seed;
    public SequentialAccountNumberGenerator(int seed = 1234567890)
        => _seed = seed;

    public string Next()
    {
        return (_seed++).ToString();
    }
}
