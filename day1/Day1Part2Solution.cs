using System.Globalization;

namespace Aoc2024;

public class Day1Part2Solution : ISolution
{
    public int GetSolution()
    {
        var (list1, list2) = File.ReadLines("day1/input")
            .Select(line => line.Split("   "))
            .Aggregate((new List<int>(), new Dictionary<int, int>()), (acc, l) =>
            {
                acc.Item1.Add(int.Parse(l[0], CultureInfo.InvariantCulture));

                int n1 = int.Parse(l[1], CultureInfo.InvariantCulture);
                int count = acc.Item2.GetValueOrDefault(n1, 0);
                acc.Item2[n1] = count + 1;

                return acc;
            });

        return list1
            .Select(item => item * list2.GetValueOrDefault(item, 0))
            .Sum();
    }
}
