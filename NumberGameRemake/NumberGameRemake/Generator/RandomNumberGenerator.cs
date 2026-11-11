namespace NumberGameRemake.Generator;

public class RandomNumberGenerator : INumberGenerator
{
    private readonly Random _rnd = new Random();
    public int Generate(int min, int max) => _rnd.Next(min, max + 1);
}
