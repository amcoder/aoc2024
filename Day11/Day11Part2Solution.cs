namespace Aoc2024;

public class Day11Part2Solution : ISolution
{
    readonly Dictionary<(long, int), long> cache = [];

    public long GetSolution()
    {
        IEnumerable<long> stones = File.ReadAllText("Day11/input")
            .Trim()
            .Split(" ")
            .Select(long.Parse);


        var result = 0L;
        foreach (var stone in stones)
        {
            result += Blink(stone, step: 75);
        }

        return result;
    }

    private long Blink(long stone, int step)
    {
        if (step == 0)
        {
            return 1;
        }

        if (cache.TryGetValue((stone, step), out var answer))
        {
            return answer;
        }

        if (stone == 0)
        {
            answer = Blink(1, step - 1);
            cache.Add((stone, step), answer);
            return answer;
        }

        var stoneString = stone.ToString();
        if (stoneString.Length % 2 == 0)
        {
            var left = long.Parse(stoneString[..(stoneString.Length / 2)]);
            var right = long.Parse(stoneString[(stoneString.Length / 2)..]);
            answer = Blink(left, step - 1) + Blink(right, step - 1);
            cache.Add((stone, step), answer);
            return answer;
        }

        answer = Blink(stone * 2024, step - 1);
        cache.Add((stone, step), answer);
        return answer;
    }
}
