namespace Aoc2024;

public class Day10Part2Solution : ISolution
{
    public long GetSolution()
    {
        var input = File.ReadLines("Day10/input")
            .Select(l => l.ToCharArray().Select(c => c - '0').ToArray())
            .ToArray();

        var width = input[0].Length;
        var height = input.Length;

        var result = 0;

        for (var row = 0; row < input.Length; row++)
        {
            for (var col = 0; col < input[row].Length; col++)
            {
                if (input[row][col] == 0)
                {
                    result += GetTrailEnds(input, row, col, 0);
                }
            }
        }

        return result;
    }

    private static int GetTrailEnds(int[][] input, int row, int col, int height)
    {
        if (height == 9)
        {
            return 1;
        }

        var result = 0;

        if (row > 0 && input[row - 1][col] == height + 1)
        {
            result += GetTrailEnds(input, row - 1, col, height + 1);
        }

        if (col > 0 && input[row][col - 1] == height + 1)
        {
            result += GetTrailEnds(input, row, col - 1, height + 1);
        }

        if (row < input.Length - 1 && input[row + 1][col] == height + 1)
        {
            result += GetTrailEnds(input, row + 1, col, height + 1);
        }

        if (col < input[row].Length - 1 && input[row][col + 1] == height + 1)
        {
            result += GetTrailEnds(input, row, col + 1, height + 1);
        }

        return result;
    }
}
