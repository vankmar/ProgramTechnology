namespace Bank;

/// <summary>
/// класс, отвечающий за проведение переводов с 1 счёта на другой
/// </summary>
public class TransferService
{
    /// <summary>
    /// метод перевода с 1 счёта на 2. Ловит и кидает исключения и совершает перевод
    /// </summary>
    /// <param name="from"> отправитель </param>
    /// <param name="to"> получатель </param>
    /// <param name="amount"> сумма </param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public void Transfer(BankAccount from, BankAccount to, decimal amount)
    {
        if (from == null) throw new ArgumentNullException(nameof(from));
        if (to == null) throw new ArgumentNullException(nameof(to));

        if (from == to) throw new ArgumentException("Cannot transfer money to the same account.");
        if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));
        if (from.Balance - amount < 0) throw new InvalidOperationException("Недостаточно средств для перевода.");

        from.MakeWithdrawal(amount, DateTime.UtcNow, $"Transfer to {to.Number}");

        try
        {
            to.MakeDeposit(amount, DateTime.UtcNow, $"Transfer from {from.Number}");
        }
        catch
        {
            from.MakeDeposit(amount, DateTime.UtcNow, $"Refund for failed transfer to {to.Number}");
            throw; // если искл. произ. в MakeDeposit - выв. его
        }
    }
}
