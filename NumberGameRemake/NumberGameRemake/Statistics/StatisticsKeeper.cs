namespace NumberGameRemake.Statistics;

public class StatisticsKeeper
{
    public int Min { get; private set; } = 0; //минимальное количество попыток
    public int Max { get; private set; } = 0; //максимальное количество попыток
    public int TotalAttemptCount { get; private set; } = 0; // общее количество попыток во всех играх
    public int GameCount { get; private set; } = 0; // количество игр
    //public int Counter = 0; // количество попыток в текущей игре
    //public int UserNumber = 0; // попытка (число)
    public int GamesWon { get; private set; }
    public double AverageAttempts
    {
        get
        {
            if (GameCount == 0) return 0;
            return TotalAttemptCount * 1.0 / GameCount;
        }
    }
}