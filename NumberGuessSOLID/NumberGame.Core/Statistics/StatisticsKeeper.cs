namespace NumberGameSOLID.Statistics;

public class StatisticsKeeper
{
    public int Min { get; private set; } = 0; //минимальное количество попыток
    public int Max { get; private set; } = 0; //максимальное количество попыток
    public int TotalAttemptCount { get; private set; } = 0; // общее количество попыток во всех играх
    public int GameCount { get; private set; } = 0; // количество игр
    //public int Counter = 0; // количество попыток в текущей игре
    //public int UserNumber = 0; // попытка (число)
    public double AverageAttempts
    {
        get
        {
            if (GameCount == 0) return 0;
            return TotalAttemptCount * 1.0 / GameCount;
        }
    }

    public void Update(int currentSessionAttempts)
    {
        GameCount++;
        TotalAttemptCount += currentSessionAttempts;

        if (Min == 0 || Min > currentSessionAttempts) Min = currentSessionAttempts; //передаём значение counter в min по усл.
        Max = Max < currentSessionAttempts ? currentSessionAttempts : Max; //то же самое с max
    }
}
