namespace NumberGameRemake.InputOutput;

public class ConsoleInputOutput : IInputOutput
{
    public string ReadLine()
    {
        string input = Console.ReadLine();
        if (input == null) return "";
        return input;
    }

    public void WriteLine(string message) => Console.WriteLine(message);
}
