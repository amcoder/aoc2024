namespace Aoc2024;

public class Day2Part2Solution : ISolution
{
    public int GetSolution()
    {
        var reports = File.ReadLines("day2/input")
            .Select(line => line.Split(" ").Select(int.Parse));

        return reports.Count(IsSafe);
    }

    private static bool IsSafe(IEnumerable<int> report)
    {
        return IsSafe(report, false);
    }

    private static bool IsSafe(IEnumerable<int> report, bool dampener)
    {
        if (report.First() > report.Last())
        {
            report = report.Reverse();
        }

        var prev = report.First();
        var count = 1;
        foreach (var item in report.Skip(1))
        {
            if (item - prev is < 1 or > 3)
            {
                if (dampener)
                {
                    return false;
                }
                else
                {
                    return IsSafe(report.Take(count - 1).Concat(report.Skip(count)), true) || IsSafe(report.Take(count).Concat(report.Skip(count + 1)), true);
                }
            }
            count++;
            prev = item;
        }

        return true;
    }
}
