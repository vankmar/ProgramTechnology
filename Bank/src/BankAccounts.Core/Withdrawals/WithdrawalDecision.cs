namespace BankAccounts.Core.Withdrawals;

// единый контракт для всех политик снятия
// возвращаем решение, а не выбрасываем исключения
// это устраняет LSP между баз и переопр методом
public sealed record WithdrawalDecision(bool IsAllowed, decimal Fee, string? RejectionReason)
{
    public static WithdrawalDecision Allow() => new(true, 0m, null);
    public static WithdrawalDecision AllowWithFee(decimal fee) => new(true, fee, null);
    public static WithdrawalDecision Reject(string reason) => new(false, 0m, reason);
}
