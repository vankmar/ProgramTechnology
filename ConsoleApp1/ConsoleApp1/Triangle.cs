namespace ConsoleApp1;

public class Triangle : Shape
{
    /// <summary>
    /// основание треугольника
    /// </summary>
    public double Base { get; set; }

    /// <summary>
    /// высота треугольника
    /// </summary>
    public double Height { get; set; }

    /// <summary>
    /// вычисляемое свойство, определяет, правильный ли треугольник
    /// </summary>
    public bool IsRight => Base > 0 && Height > 0;

    /// <summary>
    /// конструктор треугольника
    /// </summary>
    /// <param name="baseLength"> основание треугольника </param>
    /// <param name="height"> высота треугольника </param>
    /// <param name="color"> цвет треугольника </param>
    public Triangle(double baseLength, double height, string color)
        : base("Triangle", color)
    {
        Base = baseLength;
        Height = height;
        Kind = ShapeKind.Triangle;
    }

    /// <summary>
    /// считает площадь треугольника
    /// </summary>
    /// <returns> площадь треугольника </returns>
    public override double GetArea()
    {
        return Base * Height / 2;
    }

    /// <summary>
    /// возвращает строку с информацией о треугольнике, переопределённый метод
    /// </summary>
    /// <returns> описание треугольника </returns>
    public override string ToString()
    {
        return $"[Triangle] {Color}, kind: {Kind}, base={Base}, height={Height}";
    }
}