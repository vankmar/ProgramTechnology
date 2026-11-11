namespace NumberGameRemake.Settings;

public class BaseDifficultySetter : IDifficultySetter
{
    private readonly BaseDifficulty _difficulty;
    public BaseDifficultySetter(BaseDifficulty difficulty) { _difficulty = difficulty; }

    public GameSettings Settings()
    {
        if (_difficulty == BaseDifficulty.Easy)
            return new GameSettings { MinRange = 1, MaxRange = 50, MaxAttempts = 0 };

        else if (_difficulty == BaseDifficulty.Hard)
            return new GameSettings { MinRange = 1, MaxRange = 500, MaxAttempts = 10 };

        else return new GameSettings { MinRange = 1, MaxRange = 100, MaxAttempts = 10 };
    }
}
