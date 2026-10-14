namespace ConsoleApp1;

/// <summary>
/// базовый класс геом. фигур
/// </summary>
public abstract class Shape
{
    private string _name;

    /// <summary>
    /// цвет фигуры
    /// </summary>
    public string Color { get; set; }

    /// <summary>
    /// вид фигуры, по умолчанию - круг
    /// </summary>
    public ShapeKind Kind { get; set; } = ShapeKind.Circle;

    /// <summary>
    /// информация о фигуре (строка)
    /// </summary>
    public string Info => $"{Kind} ({Color})";

    /// <summary>
    /// конструктор фигуры с 2мя параметрами
    /// </summary>
    /// <param name="name"> название фигуры </param>
    /// <param name="color"> цвет фигуры </param>
    protected Shape(string name, string color)
    {
        _name = name;
        Color = color;
    }

    /// <summary>
    /// конструктор фигуры с 1м параметром, второй - чёрный цвет по ум.
    /// </summary>
    /// <param name="name"> название фигуры </param>
    protected Shape(string name) : this(name, "black")
    {
    }

    /// <summary>
    /// метод, находящий площадь фигуры
    /// </summary>
    /// <returns> площадь фигуры, double </returns>
    public abstract double GetArea();
}
