using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Aoc2024;

public partial class Program
{
    public static void Main(string[] args)
    {
        var solutions = LoadSolutions()
            .Select(s =>
            {
                var match = SolutionNameRegex().Match(s.GetType().Name);
                return (s, int.Parse(match.Groups[1].Value), int.Parse(match.Groups[2].Value));
            })
            .Where(s => args.Length == 0 || args.Contains(s.Item2.ToString()))
            .OrderBy(s => s.Item2)
            .ThenBy(s => s.Item3);

        foreach (var (solution, day, part) in solutions)
        {
            Stopwatch sw = new();

            long result;

            sw.Start();
            result = solution.GetSolution();
            sw.Stop();

            Console.WriteLine($"Day {day} Part {part}: {result}   ({sw.ElapsedMilliseconds} ms)");
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

    [GeneratedRegex(@"^Day(\d+)Part(\d+)Solution$")]
    private static partial Regex SolutionNameRegex();
}
