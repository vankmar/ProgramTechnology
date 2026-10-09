using System.Text;

namespace Bank;

// BA - потомок класса обжект

/// <summary>
/// класс банковского аккаунта
/// </summary>
public class BankAccount
{
    private readonly decimal _minimumBalance; // костыль
    private List<Transaction> _allTransations = new List<Transaction>();

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

        if (overdraftTransaction is not null)
            _allTransations.Add(overdraftTransaction);

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
    /// пустой виртуальный метод Совершить транзакцию в конце месяца
    /// </summary>
    public virtual void PerformMonthEndTransaction() { } // ключ слово виртуал позволяет в доч классе предоставить другую реализацию этого метода

    /// <summary>
    ///  переопределённый метод Перевода В Строку для класса банковского аккаунта
    /// </summary>
    /// <returns> возвращает строку </returns>
    public override string ToString() // переопр метод баз класса обж? tostr возвр строку с  инфой об объекте
    {
        return $"Owner: {Owner}\taccount number: {Number}\t type of account: {GetType()}";
    }
}

