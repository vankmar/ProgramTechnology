using NumberGameRemake.Generator;
using NumberGameRemake.Settings;

namespace NumberGameRemake.Game;

public class GameEngine(INumberGenerator generator)
{
    private readonly INumberGenerator _generator = generator;
    private GameSettings _currentSettings;
    private int _target;
    private int _attempts;
    private bool _isGameActive;

    public event EventHandler<GameNotificationEventArgs>? OnNotification;
    public event EventHandler<GameFinishedEventArgs>? OnGameFinished;

    public void StartNewRound(GameSettings settings)
    {
        _currentSettings = settings;
        _target = _generator.Generate(settings.MinRange, settings.MaxRange);
        _attempts = 0;
        _isGameActive = true;

        OnNotification?.Invoke(this, new GameNotificationEventArgs($"Игра началась!"));
    }

    public GuessResult MakeGuess(int userNumber)
    {
        if (!_isGameActive)
        {
            OnNotification?.Invoke(this, new GameNotificationEventArgs("Игра еще не запущена."));
            return GuessResult.GameNotStarted;
        }

        _attempts++;

        if (userNumber == _target)
        {
            _isGameActive = false;
            OnNotification?.Invoke(this, new GameNotificationEventArgs($"Победа! Число {_target} угадано за {_attempts} попыток."));
            OnGameFinished?.Invoke(this, new GameFinishedEventArgs(_attempts, true, _target));
            return GuessResult.Win;
        }
        if (_currentSettings.MaxAttempts > 0 && _attempts >= _currentSettings.MaxAttempts)
        {
            _isGameActive = false;
            OnNotification?.Invoke(this, new GameNotificationEventArgs($"Вы проиграли! Попытки закончились. Загаданное число: {_target}."));
            OnGameFinished?.Invoke(this, new GameFinishedEventArgs(_attempts, false, _target));
            return GuessResult.LoseOutOfAttempts;
        }
        if (userNumber > _target)
        {
            OnNotification?.Invoke(this, new GameNotificationEventArgs("Ваше число больше загаданного."));
            return GuessResult.TooHigh;
        }
        else
        {
            OnNotification?.Invoke(this, new GameNotificationEventArgs("Ваше число меньше загаданного."));
            return GuessResult.TooLow;
        }
    }
}