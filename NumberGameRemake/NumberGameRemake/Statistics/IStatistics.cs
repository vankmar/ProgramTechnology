namespace NumberGameRemake.Statistics;

public interface IStatistics
{
    StatisticsKeeper Load();
    void Save(StatisticsKeeper stats);
}