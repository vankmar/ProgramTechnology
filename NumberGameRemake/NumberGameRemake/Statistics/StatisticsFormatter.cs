using NumberGameRemake.InputOutput;

namespace NumberGameRemake.Statistics;

public class StatisticsFormatter(IInputOutput io)
{
    private readonly IInputOutput _io = io;

    public void Show(StatisticsKeeper stats)
    {
        _io.WriteLine($"Игр сыграно: {stats.GameCount} | Побед: {stats.GamesWon}");
        _io.WriteLine($"Мин. попыток: {stats.Min} | Макс. попыток: {stats.Max}");
        _io.WriteLine($"Среднее кол-во попыток: {stats.AverageAttempts}");
    }
}
