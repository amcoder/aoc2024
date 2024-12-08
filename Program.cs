using System.Diagnostics;

namespace Aoc2024;

public class Program
{
    public static void Main()
    {
        var solutions = LoadSolutions();
        foreach (var solution in solutions)
        {
            Stopwatch sw = new();

            long result;

            sw.Start();
            result = solution.GetSolution();
            sw.Stop();

            Console.WriteLine($"{solution.GetType().Name}: {result}   ({sw.ElapsedMilliseconds} ms)");
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
