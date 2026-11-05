namespace NumberGameSOLID.NumberChecker;

public class Checker
{
    public int userNumber = 0;

    public void Check()
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
}