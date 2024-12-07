namespace Aoc2024;

public class Day4Part2Solution : ISolution
{
    public int GetSolution()
    {
        var input = File.ReadLines("day4/input")
            .Select(l => l.ToCharArray())
            .ToArray();

        var width = input[0].Length;
        var height = input.Length;

        var result = 0;

        for (var row = 1; row < input.Length - 1; row++)
        {
            for (var col = 1; col < input[row].Length - 1; col++)
            {
                if (input[row][col] == 'A')
                {
                    if (input[row - 1][col - 1] == 'M' && input[row + 1][col + 1] == 'S' && input[row - 1][col + 1] == 'M' && input[row + 1][col - 1] == 'S')
                    {
                        result++;
                    }

                    if (input[row - 1][col - 1] == 'S' && input[row + 1][col + 1] == 'M' && input[row - 1][col + 1] == 'S' && input[row + 1][col - 1] == 'M')
                    {
                        result++;
                    }

                    if (input[row - 1][col - 1] == 'M' && input[row + 1][col + 1] == 'S' && input[row - 1][col + 1] == 'S' && input[row + 1][col - 1] == 'M')
                    {
                        result++;
                    }

                    if (input[row - 1][col - 1] == 'S' && input[row + 1][col + 1] == 'M' && input[row - 1][col + 1] == 'M' && input[row + 1][col - 1] == 'S')
                    {
                        result++;
                    }
                }
            }
        }

        return result;
    }
}
