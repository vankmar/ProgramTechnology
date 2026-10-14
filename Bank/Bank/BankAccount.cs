using System.Text;

namespace Bank;

// BA - потомок класса обжект

/// <summary>
/// класс банковского аккаунта
/// </summary>
public class BankAccount
{
    private readonly decimal _minimumBalance; // костыль
    /// <summary>
    /// все транзации счёта
    /// </summary>
    protected List<Transaction> _allTransations = new List<Transaction>();
    /// <summary>
    /// все операции пополнения счёта
    /// </summary>
    protected AuditLog _depositLogs = new AuditLog();
    /// <summary>
    /// все операции снятия с счёта
    /// </summary>
    protected AuditLog _withdrawalLogs = new AuditLog();
    /// <summary>
    /// все операции начисления/списания процентов для счёта
    /// </summary>
    protected AuditLog _interestLogs = new AuditLog();

    /// <summary>
    /// Владелец банковского счёта, можно менять но только внутри класса
    /// </summary>
    public string Owner { get; private set; }

    /// <summary>
    /// Номер банковского счёта
    /// </summary>
    public string Number { get; }

    /// <summary>
    /// вычисляет Баланс банковского счёта
    /// </summary>
    public decimal Balance //decimal - очень точно, для фин оп 
    { 
        get                
        {                  
            decimal balance = 0;
            foreach (var transaction in _allTransations)
                balance += transaction.Amount;
            return balance;
        }                  
    }
    /// <summary>
    /// поле - статус аккаунта.
    /// </summary>
    public AccountStatus Status { get; set; } = AccountStatus.Regular; // по ум.

    /// <summary>
    /// значения, которые может принимать статус аккаунта (Regular, Premium, VIP)
    /// </summary>
    public enum AccountStatus
    {
        /// <summary>
        /// обычный вид счёта, по умолчанию, 1
        /// </summary>
        Regular,
        /// <summary>
        /// вид счёта премиум, 2
        /// </summary>
        Premium,
        /// <summary>
        /// самый лучший вид счёта, 3
        /// </summary>
        VIP
    }

    private static int s_accountNumberSeed = 1000000000; // стаtик - это поле прин всем методам класса ( и 1 и 2 им доступ)

    /// <summary>
    /// конструктор объекта класса банковского аккаунта с двумя параметрами
    /// </summary>
    /// <param name="name"> имя владельца </param>
    /// <param name="initialBalance"> изначальный баланс </param>
    public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) 
    {
    }

    /// <summary>
    /// конструктор объекта класса банковского аккаунта с тремя параметрами
    /// </summary>
    /// <param name="name"> имя владельца </param>
    /// <param name="initialBalance"> изначальный баланс </param>
    /// <param name="minimumBalance"> минимальный баланс </param>
    public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
    {
        Owner = name;
        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;

        _minimumBalance = minimumBalance;

        //this.Balance = initialBalance; // нужно если initialBalance и Balance имеют 1 имя
        //Balance = initialBalance;

        if (initialBalance > 0)
            MakeDeposit(initialBalance, DateTime.UtcNow, "initial balance");
    }

    /// <summary>
    /// метод Пололнить на счёт на указанную сумму и логирует операцию
    /// </summary>
    /// <param name="amount"> сумма </param>
    /// <param name="date"> дата </param>
    /// <param name="note"> заметка </param>
    /// <exception cref="ArgumentOutOfRangeException"> бросается, если сумма меньше или равна 0 </exception>
    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0) throw new ArgumentOutOfRangeException (nameof(amount), "Amount of deposit must be positive");
        var deposit = new Transaction(amount, date, note);
        _allTransations.Add(deposit);

        string type = "Deposit";
        _depositLogs.Log(Number, type, amount);
    }

    /// <summary>
    ///  метод Снятия указанной суммы, также снимает штрафную сумму если есть, и логирует операцию и проверяет лимит
    /// </summary>
    /// <param name="amount"> сумма </param>
    /// <param name="date"> дата </param>
    /// <param name="note"> заметка </param>
    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);

        Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance);
        Transaction? withdrawal = new(-amount, date, note);
        
        _allTransations.Add(withdrawal);
        string type = "Withdrawal";
        _withdrawalLogs.Log(Number, type, amount);

        if (overdraftTransaction is not null)
        {
            _allTransations.Add(overdraftTransaction);
            _withdrawalLogs.Log(Number,type, 20);
        }

        //if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        //if (Balance - amount < _minimumBalance) throw new InvalidOperationException("Insufficient balance for this withdrawal");
        //var withdrawal = new Transaction(-amount, date, note);
        //_allTransations.Add(withdrawal);
    }

    /// <summary>
    /// метод Проверка на овердрафт
    /// </summary>
    /// <param name="overdrawn"> булевое значение, был ли овердрафт </param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"> неверная операция </exception>
    protected virtual Transaction? CheckWithdrawalLimit(bool overdrawn) // протектед - мод-р доступа, озн-й, что его можно вызвать только из дочер. класса и текущего
    {  // клиент/ внеш код   дан метод вызвать не может
        if (overdrawn)
            throw new InvalidOperationException("Not sufficient rubles for this withdrawal");
        else
            return default; // default - сод знач по ум., т.к. тип возвр-го зн - ссыл., то overdrawn = null (return null;)
    }

    /// <summary>
    /// метод Получить историю аккаунта
    /// </summary>
    /// <returns> возвращает строку </returns>
    public string GetAccountHistory()
    {
        var report = new StringBuilder();
        decimal balance = 0;
        report.AppendLine("Data\t\tAmount\tBalance\tNote");
        foreach (var item in _allTransations)
        {
            balance += item.Amount;
            report.AppendLine($"{item.Date.ToShortDateString()}\t\t{item.Amount}\t{balance}\t{item.Note}");
        }
        return report.ToString();
    }

    /// <summary>
    /// виртуальный метод Совершить транзакцию в конце месяца, 
    /// теперь кроме проведения транзакций ещё их и логирует и добавляет в журнал, вычисляет сумму для транзакции
    /// </summary>
    public virtual void PerformMonthEndTransaction()  // ключ слово виртуал позволяет в доч классе предоставить другую реализацию этого метода
    {
        switch (Status)
        {
            case AccountStatus.Regular:
                decimal amount1 = Balance - 50m;
                MakeWithdrawal(amount1, DateTime.UtcNow, "Apply commission");
                break;

            case AccountStatus.Premium:
                if (Balance > 10000)
                {
                    decimal amount2 = (Balance - 10000) * 0.01m;
                    Transaction? interest2 = new(amount2, DateTime.UtcNow, "Apply bonus");

                    _allTransations.Add(interest2);
                    _interestLogs.Log(Number, "Interest", amount2);

                    //MakeDeposit(interest2, DateTime.UtcNow, "Apply bonus"); // задача 1
                }
                break;

            case AccountStatus.VIP:
                if (Balance > 10000)
                {
                    decimal amount3 = (Balance - 10000) * 0.03m;

                    Transaction? interest3 = new(amount3, DateTime.UtcNow, "Apply bonus");

                    _allTransations.Add(interest3);
                    _interestLogs.Log(Number, "Interest", amount3);
                    //MakeDeposit(interest3, DateTime.UtcNow, "Apply bonus");
                }

                decimal cashback = 0;
                foreach (var trans in _allTransations)
                {
                    if (trans.Amount < 0)
                        cashback += trans.Amount;
                }
                cashback = Math.Abs(cashback);
                cashback = cashback * 0.05m;
                //MakeDeposit(cashback, DateTime.UtcNow, "Apply cashback");

                Transaction? interest = new(cashback, DateTime.UtcNow, "Apply bonus");

                _allTransations.Add(interest);
                _interestLogs.Log(Number, "Interest", cashback);
                break;
        }
    }

    /// <summary>
    ///  переопределённый метод Перевода В Строку для класса банковского аккаунта
    /// </summary>
    /// <returns> возвращает строку </returns>
    public override string ToString() // переопр метод баз класса обж? tostr возвр строку с  инфой об объекте
    {
        return $"Owner: {Owner}\taccount number: {Number}\t type of account: {GetType()}";
    }

    /// <summary>
    /// меняет статус банковского аккаунта
    /// </summary>
    /// <param name="status"> статус банковского аккаунта </param>
    public void ChangeAccountStatus(AccountStatus status)
    {
        Status = status;
    }

    /// <summary>
    /// вывод журналов для опреаций пополнения счёта
    /// </summary>
    public void ShowDepositLogs()
    {
        _depositLogs.ShowLogs();
    }
    /// <summary>
    /// вывод журналов для опреаций снятия с счёта
    /// </summary>
    public void ShowWithdrawalLogs()
    {
        _withdrawalLogs.ShowLogs();
    }
    /// <summary>
    /// вывод журналов для процентов
    /// </summary>
    public void ShowInterestLogs()
    {
        _interestLogs.ShowLogs();
    }

}

