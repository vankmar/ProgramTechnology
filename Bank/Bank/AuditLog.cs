namespace Bank;

/// <summary>
/// класс для ведения журналов по операциям
/// </summary>
public class AuditLog
{
    private List<string> _allLogs = new List<string>();

    /// <summary>
    ///  создаёт строку, которую затем логирует её в журнал
    /// </summary>
    /// <param name="number"> номер счёта </param>
    /// <param name="type"> тип операции </param>
    /// <param name="amount"> сумма </param>
    public void Log(string number, string type, decimal amount)
    {
        string entry = $"Счёт: {number} | " + $"Тип: {type} | " + $"Сумма: {amount} | " + $"Дата: {DateTime.UtcNow}";
        _allLogs.Add(entry);
    }

    /// <summary>
    /// вывод журналов
    /// </summary>
    public void ShowLogs()
    {
        foreach (string entry in _allLogs)
        {
            Console.WriteLine(entry);
        }
    }
}