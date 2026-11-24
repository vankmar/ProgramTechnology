namespace NumberGameRemake.Game;

public class GameFinishedEventArgs(int attempts, bool isWin, int targetNumber) : EventArgs
{
    public int Attempts { get; } = attempts;
    public bool IsWin { get; } = isWin;
    public int Target { get; } = targetNumber;
}