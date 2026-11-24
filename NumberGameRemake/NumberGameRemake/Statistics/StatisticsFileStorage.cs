namespace NumberGameRemake.Statistics;

public class StatisticsFileStorage : IStatistics
{
    private readonly string _filePath;
    public StatisticsFileStorage(string filePath) { _filePath = filePath; }

    public StatisticsKeeper Load()
    {
        var stats = new StatisticsKeeper();
        if (!File.Exists(_filePath)) return stats;

        using (StreamReader reader = new StreamReader(_filePath))
        {
            if (int.TryParse(reader.ReadLine(), out int min)) stats.Min = min;
            if (int.TryParse(reader.ReadLine(), out int max)) stats.Max = max;
            if (int.TryParse(reader.ReadLine(), out int total)) stats.TotalAttemptCount = total;
            if (int.TryParse(reader.ReadLine(), out int played)) stats.GameCount = played;
            if (int.TryParse(reader.ReadLine(), out int won)) stats.GamesWon = won;
        }

        return stats;
    }

    public void Save(StatisticsKeeper stats)
    {
        using (StreamWriter writer = new StreamWriter(_filePath))
        {
            writer.WriteLine(stats.Min);
            writer.WriteLine(stats.Max);
            writer.WriteLine(stats.TotalAttemptCount);
            writer.WriteLine(stats.GameCount);
            writer.WriteLine(stats.GamesWon);
        }
    }
}
