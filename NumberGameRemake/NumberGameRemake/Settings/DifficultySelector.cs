using NumberGameRemake.InputOutput;

namespace NumberGameRemake.Settings;

public class DifficultySelector
{
    private readonly IInputOutput _io;
    public DifficultySelector(IInputOutput io) { _io = io; }


    public IDifficultySetter Select()
    {
        _io.WriteLine("Выберите режим: 1 - Легкий, 2 - Средний, 3 - Сложный, 4 - Свои настройки");
        string choice = _io.ReadLine();

        if (choice == "4") return new CustomDifficultySetter(_io);
        else if (choice == "1") return new BaseDifficultySetter(BaseDifficulty.Easy);
        else if (choice == "2") return new BaseDifficultySetter(BaseDifficulty.Medium);
        else if (choice == "3") return new BaseDifficultySetter(BaseDifficulty.Hard);
        else
        {
            _io.WriteLine("Такого уровня сложномти нет. Выбран средний по умолчанию.");
            return new BaseDifficultySetter(BaseDifficulty.Medium);
        }
    }
}