using NumberGameRemake.InputOutput;

namespace NumberGameRemake.Settings;

public class CustomDifficultySetter : IDifficultySetter
{
    private readonly IInputOutput _io;
    public CustomDifficultySetter(IInputOutput io) { _io = io; }

    public GameSettings Settings()
    {
        int min = Set("Введите минимальное число диапазона: ");
        int max = Set("Введите максимальное число диапазона: ");
        int attempts = Set("Введите количество попыток (0 — без ограничений): ");

        return new GameSettings
        {
            MinRange = min,
            MaxRange = max,
            MaxAttempts = attempts
        };
    }
    private int Set(string message) // вспомогательный метод
    {
        int parameter;
        _io.WriteLine(message);

        while (true)
        {
            if (!int.TryParse(_io.ReadLine(), out parameter))
                _io.WriteLine(message);
            else break;
        }
        return parameter;
    }
}
