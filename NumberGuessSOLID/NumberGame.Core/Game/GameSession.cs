using NumberGameSOLID.NumberChecker;
using NumberGameSOLID.Statistics;
using System.Data;

namespace NumberGameSOLID.Game;

internal class GameSession
{
    private readonly Random _rnd = new Random();
    private readonly Checker _checker = new Checker();

    public int Play()
    {
        _checker.userNumber = 0;
        int target = _rnd.Next(1, 101);
        int attemptCount = 0;

        while (true)//выполняется в любом случае
        {
            attemptCount++;//инкремент текущих попыток

            Console.WriteLine("input number from [1;100]");
            _checker.Check(); //вызов метода проверки числа

            if (_checker.userNumber > target)// если введённое меньше загаданного
                Console.WriteLine("your number is greater"); //прога скажет твое число меньше

            else if (_checker.userNumber < target) // если введённое больше загаданного
                Console.WriteLine("your number is less");//прога скажет твое число больше

            else // введённое = загаданному
            {
                Console.WriteLine("YOU ARE WIN"); //победа
                break; // выход из условия
            }
        }
        return attemptCount; // т.к. метод - int, то нужно использовать return чтобы не было ошибки
    }
}
