namespace Aoc2024;

public class Day2Part1Solution : ISolution
{
    public int GetSolution()
    {
        var reports = File.ReadLines("day2/input")
            .Select(line => line.Split(" ").Select(int.Parse));

        return reports.Count(IsSafe);
    }

    private static bool IsSafe(IEnumerable<int> report)
    {
        if (report.First() > report.Last())
        {
            report = report.Reverse();
        }

        var prev = report.First();
        foreach (var item in report.Skip(1))
        {
            if (item - prev is < 1 or > 3)
            {
                return false;
            }
            prev = item;
        }

        return true;
    }
}
