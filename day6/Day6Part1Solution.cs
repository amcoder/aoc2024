namespace Aoc2024;

public class Day6Part1Solution : ISolution
{
    public int GetSolution()
    {
        var map = File.ReadLines("day6/input")
            .Select(l => l.ToCharArray())
            .ToArray();

        var width = map[0].Length;
        var height = map.Length;
        var position = (0, 0);
        var direction = "up";

        for (var row = 0; row < height; row++)
        {
            for (var col = 0; col < width; col++)
            {
                if (map[row][col] == '^')
                {
                    position = (row, col);
                    map[row][col] = 'X';
                }
            }
        }

        while (true)
        {
            var (row, col) = position;

            var (newRow, newCol) = direction switch
            {
                "up" => (row - 1, col),
                "down" => (row + 1, col),
                "left" => (row, col - 1),
                "right" => (row, col + 1),
                _ => throw new Exception("Invalid direction")
            };

            if (newRow < 0 || newRow >= height || newCol < 0 || newCol >= width)
            {
                break;
            }

            if (map[newRow][newCol] == '#')
            {
                direction = direction switch
                {
                    "up" => "right",
                    "right" => "down",
                    "down" => "left",
                    "left" => "up",
                    _ => throw new Exception("Invalid direction")
                };
                continue;
            }

            map[newRow][newCol] = 'X';
            position = (newRow, newCol);
        }

        return map.Select(l => l.Count(c => c == 'X')).Sum();
    }
}
