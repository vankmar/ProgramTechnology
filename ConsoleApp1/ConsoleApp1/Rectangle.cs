namespace ConsoleApp1;

public class Rectangle : Shape
{
    /// <summary>
    /// длина прямоугольника
    /// </summary>
    public double Width { get; set; }

    /// <summary>
    /// высота прямоугольника
    /// </summary>
    public double Height { get; set; }

    /// <summary>
    /// вычисляемое свойство, определяет является ли прямоугольника квадратом
    /// </summary>
    public bool IsSquare => Width == Height;

    /// <summary>
    /// конструктор прямоугольника
    /// </summary>
    /// <param name="width"> длина прямоугольника </param>
    /// <param name="height"> высота прямоугольника </param>
    /// <param name="color"> цвет прямоугольника </param>
    public Rectangle(double width, double height, string color)
        : base("Rectangle", color)
    {
        Width = width;
        Height = height;
        Kind = ShapeKind.Rectangle;
    }

    /// <summary>
    /// метод, рассчитывающий площадь прямоугольника
    /// </summary>
    /// <returns> площадь прямоугольника </returns>
    public override double GetArea()
    {
        _areaGetCount++;
        return Width * Height;
    }

    /// <summary>
    /// возвращает строку с информацией о прямоугольнике, переопределённый метод
    /// </summary>
    /// <returns> описание прямоугольника </returns>
    public override string ToString()
    {
        return $"[Rectangle] {Color}, kind: {Kind}, {Width}x{Height}";
    }

    private int _areaGetCount;
    public int GetAreaGetCount()
    {
        return _areaGetCount;
    }
}
