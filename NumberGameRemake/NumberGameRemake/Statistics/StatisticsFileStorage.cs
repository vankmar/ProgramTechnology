namespace NumberGameRemake.Statistics;

public class StatisticsFileStorage : IStatistics
{
    public StatisticsKeeper Load(string playerName)
    {
        var stats = new StatisticsKeeper(playerName);
        string filePath = $"stats_{playerName}.txt";

        if (!File.Exists(filePath)) return stats;

        using (StreamReader reader = new StreamReader(filePath))
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
        using (StreamWriter writer = new StreamWriter($"stats_{stats.Player}.txt"))
        {
            writer.WriteLine(stats.Min);
            writer.WriteLine(stats.Max);
            writer.WriteLine(stats.TotalAttemptCount);
            writer.WriteLine(stats.GameCount);
            writer.WriteLine(stats.GamesWon);
        }
    }
}
