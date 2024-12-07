namespace Aoc2024;

public class Day5Part2Solution : ISolution
{
    public int GetSolution()
    {
        var lines = File.ReadLines("day5/input");

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
            .Where(update => !IsOrdered(update, rules))
            .Select(update => Order(update, rules))
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

    private static int[] Order(IEnumerable<int> update, Dictionary<int, List<int>> rules)
    {
        var list = update.ToList();
        List<int> result = [list[0]];

        for (var i = 1; i < list.Count; i++)
        {
            var j = 0;
            for (; j < result.Count; j++)
            {
                if (rules.TryGetValue(list[i], out var value) && value.Contains(result[j]))
                {
                    result.Insert(j, list[i]);
                    break;
                }
            }
            if (j == result.Count)
            {
                result.Add(list[i]);
            }
        }

        return [.. result];
    }
}
