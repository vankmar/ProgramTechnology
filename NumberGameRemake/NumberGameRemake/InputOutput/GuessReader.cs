namespace NumberGameRemake.InputOutput;

public class GuessReader(IInputOutput io)
{
    private readonly IInputOutput _io = io;

    public int? ReadGuess(int min, int max)
    {
        for (int i = 0; i < 3; i++)
        {
            _io.WriteLine($"Введите число от {min} до {max}:");
            if (int.TryParse(_io.ReadLine(), out int number) && number >= min && number <= max)
                return number;
            _io.WriteLine("Некорректный ввод! Попробуйте снова.");
        }
        return null;
    }
}
