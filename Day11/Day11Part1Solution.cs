namespace Aoc2024;

public class Day11Part1Solution : ISolution
{
    public long GetSolution()
    {
        IEnumerable<string> stones = File.ReadAllText("Day11/input")
            .Trim()
            .Split(" ");

        for (var i = 0; i < 25; i++)
        {
            stones = Blink(stones);
        }

        return stones.Count();
    }

    private static IEnumerable<string> Blink(IEnumerable<string> stones)
    {
        foreach (var stone in stones)
        {
            if (stone == "0")
            {
                yield return "1";
            }
            else if (stone.Length % 2 == 0)
            {
                yield return stone[..(stone.Length / 2)];
                yield return long.Parse(stone[(stone.Length / 2)..]).ToString();
            }
            else
            {
                yield return (long.Parse(stone) * 2024).ToString();
            }
        }
    }
}
