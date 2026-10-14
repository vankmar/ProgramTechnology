namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>
        {
            new Circle(5, "red"),
            new Rectangle(4, 6, "blue"),
            new Triangle(3, 4, "green")
        };

        foreach (Shape shape in shapes) // проверка полиморфизма перебором
        {
            Console.WriteLine(shape);

            if (shape is Circle circle)
                Console.WriteLine($"  diameter: {circle.Diameter}, area: {circle.GetArea():F2}");
            else if (shape is Rectangle rectangle)
                Console.WriteLine($"  is square: {rectangle.IsSquare}, area: {rectangle.GetArea():F2}");
            else if (shape is Triangle triangle)
                Console.WriteLine($"  is right: {triangle.IsRight}, area: {triangle.GetArea():F2}");

            // проверка интерфейса
            if (shape is IScalable scalable)
            {
                scalable.Scale(2);
                Console.WriteLine($"{shape.GetType().Name} scaled by 2.");
            }
            else
                Console.WriteLine($"{shape.GetType().Name} cannot scale.");
            Console.WriteLine();
        }
        Console.WriteLine();

        //проверка приватного поля
        Circle circle1 = new Circle(1, "pink");
        shapes.Add(circle1);
        Console.WriteLine($"{circle1}, scale count: {circle1.GetScaleCount()}");

        circle1.Scale(2);
        circle1.Scale(2);
        circle1.Scale(2);
        circle1.Scale(2);

        Console.WriteLine($"{circle1}, scale count: {circle1.GetScaleCount()}");
    }
}
