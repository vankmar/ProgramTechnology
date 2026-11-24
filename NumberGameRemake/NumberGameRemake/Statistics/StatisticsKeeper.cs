namespace NumberGameRemake.Statistics;

public class StatisticsKeeper(string player)
{
    public string Player { get; set; } = player;
    public int Min { get; set; } = 0; //минимальное количество попыток
    public int Max { get; set; } = 0; //максимальное количество попыток
    public int TotalAttemptCount { get; set; } = 0; // общее количество попыток во всех играх
    public int GameCount { get; set; } = 0; // количество игр
    //public int Counter = 0; // количество попыток в текущей игре
    //public int UserNumber = 0; // попытка (число)
    public int GamesWon { get; set; }
    public double AverageAttempts
    {
        get
        {
            if (GameCount == 0) return 0;
            return TotalAttemptCount * 1.0 / GameCount;
        }
    }

    public void RecordStatistics(int attempts, bool isWin)
    {
        GameCount++;
        TotalAttemptCount += attempts;

        if (isWin)
        {
            GamesWon++;
            if (Min == 0 || attempts < Min) Min = attempts;
            if (attempts > Max) Max = attempts;
        }
    }
}