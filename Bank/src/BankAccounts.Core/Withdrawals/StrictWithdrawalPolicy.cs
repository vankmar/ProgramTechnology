namespace BankAccounts.Core.Withdrawals; 

// политика по умолчанию : если баланс ниже минимума - отклоняем 
public sealed class StrictWithdrawalPolicy : IWithdrawalPolicy
{
    public WithdrawalDecision Evaluate(decimal currentBalance, decimal amount, decimal minimumBalance)
        => currentBalance - amount < minimumBalance 
        ? WithdrawalDecision.Reject("Not sufficient rubles for this operation")  
        : WithdrawalDecision.Allow();
}
