using NumberGameRemake.Game;
using NumberGameRemake.Generator;
using NumberGameRemake.Settings;
using NumberGameRemake.Statistics;
using NumberGameRemake.InputOutput;

namespace ConsoleGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IInputOutput io = new ConsoleInputOutput();
            INumberGenerator generator = new RandomNumberGenerator();
            IStatistics storage = new StatisticsFileStorage();

            DifficultySelector selector = new DifficultySelector(io); // базовая / кастомная
            GuessReader reader = new GuessReader(io);
            StatisticsFormatter formatter = new StatisticsFormatter(io); 
            GameEngine engine = new GameEngine(generator);

            io.WriteLine("Введите ваше имя:");
            string player = io.ReadLine().Trim();
            if (string.IsNullOrEmpty(player)) 
                player = "DefaultPlayer";

            StatisticsKeeper currentStats = storage.Load(player);

            engine.OnNotification += (s, e) => io.WriteLine($"[ИГРА]: {e.Message}");
            engine.OnGameFinished += (sender, e) =>
            {
                currentStats.RecordStatistics(e.Attempts, e.IsWin);
                storage.Save(currentStats);
            };

            string playAgain;
            do
            {
                IDifficultySetter setter = selector.Select();
                GameSettings settings = setter.Settings();

                engine.StartNewRound(settings);

                while (true)
                {
                    int? guess = reader.ReadGuess(settings.MinRange, settings.MaxRange);
                    if (guess == null)
                    {
                        io.WriteLine("Превышен лимит ошибок ввода. Раунд завершен.");
                        break;
                    }
                    GuessResult result = engine.MakeGuess(guess.Value);

                    if (result == GuessResult.Win || result == GuessResult.LoseOutOfAttempts)
                        break;
                }

                formatter.Show(currentStats);
                Console.WriteLine("Сыграть еще раз? (Y/N):");
                playAgain = Console.ReadLine()?.Trim().ToUpper() ?? "N";
            } while (playAgain == "Y");
        }
    }
}
