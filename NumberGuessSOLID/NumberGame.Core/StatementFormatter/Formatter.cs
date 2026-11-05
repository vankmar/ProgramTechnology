using NumberGameSOLID.Statistics;
namespace NumberGameSOLID.StatementFormatter;

public class Formatter
{
    public string Format(StatisticsKeeper stats)
    {
        return $"min = {stats.Min} max = {stats.Max} avg = {stats.AverageAttempts}";
    }
}
