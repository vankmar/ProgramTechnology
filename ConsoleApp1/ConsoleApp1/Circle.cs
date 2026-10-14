namespace ConsoleApp1;

/// <summary>
/// круг
/// </summary>
public class Circle : Shape, IScalable
{
    /// <summary>
    /// радиус круга, автоматическое свойство
    /// </summary>
    public double Radius { get; set; }

    /// <summary>
    /// диаметр круга, вычисляемое свойство
    /// </summary>
    public double Diameter => Radius * 2;

    /// <summary>
    /// конструктор круга
    /// </summary>
    /// <param name="radius"> радиус круга </param>
    /// <param name="color"> цвет круга </param>
    public Circle(double radius, string color) : base("Circle", color)
    {
        Radius = radius;
        Kind = ShapeKind.Circle;
    }

    /// <summary>
    /// расчитывает площадь круга
    /// </summary>
    /// <returns> площадь круга </returns>
    public override double GetArea()
    {
        return Math.PI * Radius * Radius;
    }

    /// <summary>
    /// масштабирует круг по фактору
    /// </summary>
    /// <param name="factor"> фактор </param>
    public void Scale(double factor)
    {
        if (factor <= 0)
            throw new ArgumentOutOfRangeException(nameof(factor), "The scaling factor must be positive.");
        Radius *= factor;
        _scaleCount++;
    }

    /// <summary>
    /// возвращает строку с информацией о круге, переопределённый метод
    /// </summary>
    /// <returns> описание круга, строка </returns>
    public override string ToString()
    {
        return $"[Circle] {Color}, kind: {Kind}, r={Radius}";
    }

    private int _scaleCount;
    
    public int GetScaleCount()
    {
        return _scaleCount;
    }
}
