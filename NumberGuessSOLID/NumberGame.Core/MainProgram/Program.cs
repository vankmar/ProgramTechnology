using NumberGameSOLID.Game;
using NumberGameSOLID.StatementFormatter;
using NumberGameSOLID.Statistics;
namespace NumberGameSOLID.MainProgram;

internal class Program
{

    static void Main(string[] args)
    {
        GameSession game = new GameSession();
        StatisticsKeeper statistics = new StatisticsKeeper();
        Formatter formatter = new Formatter();

        char anwser = 'Y'; // ответ, который нужен для повторной игры

        do // тело срабатывает до проверки условия, то есть как минимум 1 раз
        {
            int attempts = game.Play(); //вызов метода, где игра
            statistics.Update(attempts);
            string stats = formatter.Format(statistics);
            Console.WriteLine(stats);
            Console.WriteLine("wanna play again? [Y for yes]");
            anwser = Convert.ToChar(Console.Read());// anwser = тому, что введём
        } while (anwser == 'Y');//работает, пока не введём в anwser что-то кроме Y
    }
}
