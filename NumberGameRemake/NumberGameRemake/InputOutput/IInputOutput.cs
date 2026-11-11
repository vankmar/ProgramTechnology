namespace NumberGameRemake.InputOutput;

internal interface IInputOutput // для того, чтобы не зависеть именно от консоли
{
    void WriteLine(string message);
    string ReadLine();
}
