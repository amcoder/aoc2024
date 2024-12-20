namespace Aoc2024;

public class Day5Part1Solution : ISolution
{
    public long GetSolution()
    {
        var lines = File.ReadLines("Day05/input");

        var rules = lines.TakeWhile(l => l.Length > 0)
            .Select(l => l.Split('|').Select(int.Parse).ToArray())
            .Aggregate(new Dictionary<int, List<int>>(), (acc, r) =>
            {
                var list = acc.GetValueOrDefault(r[0]);
                if (list == null)
                {
                    acc[r[0]] = [r[1]];
                }
                acc[r[0]].Add(r[1]);
                return acc;
            });

        var updates = lines.SkipWhile(l => l.Length > 0).Skip(1)
            .Select(l => l.Split(',').Select(int.Parse).ToArray());

        var result = updates
            .Where(update => IsOrdered(update, rules))
            .Select(update => update[update.Length / 2])
            .Sum();


        return result;
    }

    private static bool IsOrdered(IEnumerable<int> update, Dictionary<int, List<int>> rules)
    {
        var list = update.ToList();
        for (var i = 1; i < list.Count; i++)
        {
            for (var j = 0; j < i; j++)
            {
                if (rules.TryGetValue(list[i], out var value) && value.Contains(list[j]))
                {
                    return false;
                }
            }
        }

        return true;
    }
}
