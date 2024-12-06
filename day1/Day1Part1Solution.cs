using System.Globalization;

namespace Aoc2024;

public class Day1Part1Solution : ISolution
{
    public int GetSolution()
    {
        var (list1, list2) = File.ReadLines("day1/input")
            .Select(line => line.Split("   "))
            .Aggregate((new List<int>(), new List<int>()), (acc, l) =>
            {
                acc.Item1.Add(int.Parse(l[0], CultureInfo.InvariantCulture));
                acc.Item2.Add(int.Parse(l[1], CultureInfo.InvariantCulture));
                return acc;
            });

        list1.Sort();
        list2.Sort();

        return list1.Zip(list2, (a, b) => a - b)
            .Select(Math.Abs)
            .Sum();
    }
}
