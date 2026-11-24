namespace NumberGameRemake.Statistics;

public interface IStatistics
{
    StatisticsKeeper Load(string playerName);
    void Save(StatisticsKeeper stats);
}