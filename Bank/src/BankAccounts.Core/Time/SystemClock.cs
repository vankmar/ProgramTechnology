namespace BankAccounts.Core.Time;

//реализвация дял
public sealed class  SystemClock : IClock
{
    public DateTime Now => DateTime.UtcNow;
}

