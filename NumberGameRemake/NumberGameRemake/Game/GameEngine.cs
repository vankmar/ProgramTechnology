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

    public event EventHandler<GameNotificationEventArgs>? Notification;
    public event EventHandler<GameFinishedEventArgs>? GameFinished;  

    public void StartNewRound(GameSettings settings) 
    { 
        _currentSettings = settings;
        _target = _generator.Generate(settings.MinRange, settings.MaxRange); 
        _attempts = 0;
        _isGameActive = true;

        OnNotification(new GameNotificationEventArgs($"Игра началась! Количество попыток: {settings.MaxAttempts}"));
    }

    public GuessResult MakeGuess(int userNumber)
    {
        if (!_isGameActive)
        {
            OnNotification(new GameNotificationEventArgs("Игра еще не запущена."));
            return GuessResult.GameNotStarted;
        }

        _attempts++;

        if (userNumber == _target) 
        {
            _isGameActive = false;
            OnNotification(new GameNotificationEventArgs($"Победа! Число {_target} угадано за {_attempts} попыток."));
            OnGameFinished(new GameFinishedEventArgs(_attempts, true, _target));
            return GuessResult.Win;
        }
        if (_currentSettings.MaxAttempts > 0 && _attempts >= _currentSettings.MaxAttempts)
        {
            _isGameActive = false;
            OnNotification(new GameNotificationEventArgs($"Вы проиграли! Попытки закончились. Загаданное число: {_target}."));
            OnGameFinished(new GameFinishedEventArgs(_attempts, false, _target));
            return GuessResult.LoseOutOfAttempts;
        }
        if (userNumber > _target)
        {
            OnNotification(new GameNotificationEventArgs("Ваше число больше загаданного."));
            return GuessResult.TooHigh;
        }
        else
        {
            OnNotification(new GameNotificationEventArgs("Ваше число меньше загаданного."));
            return GuessResult.TooLow;
        }
    }

    protected virtual void OnNotification(GameNotificationEventArgs e)
        => Notification?.Invoke(this, e);
    protected virtual void OnGameFinished(GameFinishedEventArgs e)
        => GameFinished?.Invoke(this, e);
}