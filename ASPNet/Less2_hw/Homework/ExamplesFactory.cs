namespace Homework;

public class ExamplesFactory
{
    private readonly int _min;
    private readonly int _max;
    private readonly Random _random = new Random();

    public ExamplesFactory(int min = 2, int max = 10)
    {
        _min = min;
        _max = max;
    }

    public IEnumerable<(int a, int b, int ans)> GetExamples(int num)
    {
        var examples = new List<(int a, int b, int ans)>();

        var n = 0;
        while (n < num)
        {
            var a = GetRandom();
            var b = GetRandom();
            if (examples.Exists(p => (p.a == a && p.b == b) || (p.a == b && p.b == a))) continue;
            examples.Add((a, b, a * b));
            n++;
        }

        return examples;
    }

    private int GetRandom()
    {
        return _random.Next(_min, _max);
    }
}