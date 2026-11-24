namespace NumberGameRemake.Game;

public class GameNotificationEventArgs(string message) : EventArgs
{
    public string Message { get; } = message;
}