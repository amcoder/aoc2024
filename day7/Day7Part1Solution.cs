using System.Globalization;

namespace Aoc2024;

public class Day7Part1Solution : ISolution
{
    public long GetSolution()
    {
        var map = File.ReadLines("day7/input")
            .Select(l => l.Split(": "))
            .Select(l => (long.Parse(l[0], CultureInfo.InvariantCulture), l[1].Split(' ').Select(long.Parse).Reverse().ToArray()));

        var result = map
            .Where(l => IsValid(l.Item1, l.Item2))
            .Select(l => l.Item1)
            .Sum();

        return result;
    }

    private static bool IsValid(long value, long[] operands)
    {
        foreach (var item in Calculate(operands[0], operands.Skip(1).ToArray()))
        {
            if (item == value)
            {
                return true;
            }
        }

        return false;
    }

    private static IEnumerable<long> Calculate(long result, IEnumerable<long> rest)
    {
        if (!rest.Any())
        {
            yield return result;
        }
        else
        {
            foreach (var item in Calculate(rest.First(), rest.Skip(1)))
            {
                yield return result + item;
                yield return result * item;
            }
        }
    }
}
