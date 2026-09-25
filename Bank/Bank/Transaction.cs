namespace Bank;

/// <summary>
/// Тип данных, который запрещает менять состояние объекта
/// </summary>
/// <param name="Amount"> сумма транзакции </param>
/// <param name="Date"> дата транзакции </param>
/// <param name="Note"> заметки к транзакции </param>
internal record Transaction(decimal Amount, DateTime Date, string Note); // тк транс - неизм-й объект (запись)

//internal record Transaction
//{
//    public decimal Amount { get; }
//    public DateTime Date { get; }
//    // и т.д. - в (decimal Amount, DateTime Date, string Note)
//}
