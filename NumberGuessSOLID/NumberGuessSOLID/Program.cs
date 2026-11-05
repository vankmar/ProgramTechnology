namespace NumberGuessOld
{
    internal class Program
    {
        static int min = 0; //минимальное количество попыток
        static int max = 0; //максимальное количество попыток
        static int count = 0; // общее количество попыток во всех играх
        static int countGame = 0; // количество игр
        static int counter = 0; // количество попыток в текущей игре
        static int userNumber = 0; // попытка (число)
                                   // сама игра
        static int oneGame(Random rnd, ref int min, ref int max, ref int count, ref int countGame)
        {
            int number = rnd.Next(1, 101);//случайное число от 1 до 100
            while (true)//выполняется в любом случае
            {
                counter++;//инкремент текущих попыток
                Console.WriteLine("input number from [1;100]");
                numberCheck(); //вызов метода проверки числа
                if (userNumber > number)// если введённое меньше загаданного
                    Console.WriteLine("your number is greater"); //прога скажет твое число меньше
                else if (userNumber < number) // если введённое больше загаданного
                    Console.WriteLine("your number is less");//прога скажет твое число больше
                else// введённое = загаданному
                {
                    Console.WriteLine("YOU ARE WIN"); //победа
                    statistics(); //подсчёт статистики
                    counter = 0; //т.к. эту переменную вынесла за методы и использую в нескольких 
                    userNumber = 0;// тоже
                    break; //выход из условия
                }
            }
            return counter;// т.к. метод - int, то нужно использовать return чтобы не было ошибки
        }
        //проверка введённого числа
        static void numberCheck()
        {
            for (int i = 0; i < 3; i++) //всего 3 попытки неправильного ввода
            {
                if (!int.TryParse(Console.ReadLine(), out userNumber) // если НЕ выходит разобрать число
                    || userNumber > 100 // или оно за пределами 
                    || userNumber < 1)
                    Console.WriteLine("input number from [1;100]"); //запускает ещё одну попытку 
                else break; // если число  в пределах и разобрано, то выходим из цикла
                if (i == 2) //еслы колиство неправильных вводов - 3
                {
                    Console.WriteLine("you're stupid");
                    userNumber = 0; //введённое число обнуляется
                                    //т.к. эту переменную вынесла за методы и использую в нескольких 
                    Environment.Exit(0); //выход из программы
                }
            }
        }
        //ведение статистики
        static void statistics()
        {
            if (min == 0 || min > counter) min = counter; //передаём значение counter в min по усл.
            max = max < counter ? counter : max; //то же самое с max
            countGame++; // инкремент кол-ва игр
            count += counter; //к общему кол-ву попыток прибавляем текущее
        }
        // вывод на экран статистики
        static void showStatistics()
        {
            Console.WriteLine($"min = {min} max = {max} avg = {count * 1.0 / countGame}");
        }
        //точка входа в программу
        static void Main(string[] args)
        {
            Random rnd = new(); // генератор случайных чисел
            char anwser = 'Y'; // ответ, который нужен для повторной игры
            do // тело срабатывает до проверки условия, то есть как минимум 1 раз
            {
                oneGame(rnd, ref min, ref max, ref count, ref countGame); //вызов метода, где игра
                showStatistics(); //вызод метода показа статистик
                Console.WriteLine("wanna play again?");
                anwser = Convert.ToChar(Console.Read());// anwser = тому, что введём
            } while (anwser == 'Y');//работает, пока не введём в anwser что-то кроме Y
        }
    }
}
