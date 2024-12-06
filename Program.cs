namespace Aoc2024;

public class Program
{
    public static void Main()
    {
        var solutions = LoadSolutions();
        foreach (var solution in solutions)
        {
            Console.WriteLine($"{solution.GetType().Name}: {solution.GetSolution()}");
        }
    }

    public static IEnumerable<ISolution> LoadSolutions()
    {
        return AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => t.IsClass)
            .Where(t => t.IsAssignableTo(typeof(ISolution)))
            .Select(t => (ISolution)Activator.CreateInstance(t)!);
    }
}
