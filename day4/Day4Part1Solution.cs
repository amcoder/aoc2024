namespace Aoc2024;

public class Day4Part1Solution : ISolution
{
    public int GetSolution()
    {
        var input = File.ReadLines("day4/input")
            .Select(l => l.ToCharArray())
            .ToArray();

        var width = input[0].Length;
        var height = input.Length;

        var result = 0;

        for (var row = 0; row < input.Length; row++)
        {
            for (var col = 0; col < input[row].Length; col++)
            {
                if (input[row][col] == 'X')
                {
                    if (col < width - 3 && input[row][col + 1] == 'M' && input[row][col + 2] == 'A' && input[row][col + 3] == 'S')
                    {
                        result++;
                    }

                    if (row < height - 3 && input[row + 1][col] == 'M' && input[row + 2][col] == 'A' && input[row + 3][col] == 'S')
                    {
                        result++;
                    }

                    if (col > 2 && input[row][col - 1] == 'M' && input[row][col - 2] == 'A' && input[row][col - 3] == 'S')
                    {
                        result++;
                    }

                    if (row > 2 && input[row - 1][col] == 'M' && input[row - 2][col] == 'A' && input[row - 3][col] == 'S')
                    {
                        result++;
                    }

                    if (row < height - 3 && col < width - 3 && input[row + 1][col + 1] == 'M' && input[row + 2][col + 2] == 'A' && input[row + 3][col + 3] == 'S')
                    {
                        result++;
                    }

                    if (row > 2 && col < width - 3 && input[row - 1][col + 1] == 'M' && input[row - 2][col + 2] == 'A' && input[row - 3][col + 3] == 'S')
                    {
                        result++;
                    }

                    if (row < height - 3 && col > 2 && input[row + 1][col - 1] == 'M' && input[row + 2][col - 2] == 'A' && input[row + 3][col - 3] == 'S')
                    {
                        result++;
                    }

                    if (row > 2 && col > 2 && input[row - 1][col - 1] == 'M' && input[row - 2][col - 2] == 'A' && input[row - 3][col - 3] == 'S')
                    {
                        result++;
                    }
                }
            }
        }

        return result;
    }
}
