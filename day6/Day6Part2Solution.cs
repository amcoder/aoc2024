namespace Aoc2024;

public class Day6Part2Solution : ISolution
{
    public long GetSolution()
    {
        var map = File.ReadLines("day6/input")
            .Select(l => l.ToCharArray())
            .ToArray();

        var baseMap = map.Select(l => l.ToArray()).ToArray();

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
                    baseMap[row][col] = '.';
                }
            }
        }

        var result = 0;

        while (true)
        {
            var (newRow, newCol) = NextPosition(position, direction);

            if (newRow < 0 || newRow >= height || newCol < 0 || newCol >= width)
            {
                break;
            }

            if (map[newRow][newCol] == '#')
            {
                direction = Turn(direction);
                continue;
            }

            // Test if an obstruction at next position would cause a loop
            if (map[newRow][newCol] != 'X')
            {
                var newMap = baseMap.Select(l => l.ToArray()).ToArray();
                newMap[newRow][newCol] = '#';
                if (IsLoop(newMap, position, direction))
                {
                    result++;
                }
            }

            map[newRow][newCol] = 'X';
            position = (newRow, newCol);
        }

        return result;
    }

    private static bool IsLoop(char[][] map, (int, int) position, string direction)
    {
        var width = map[0].Length;
        var height = map.Length;

        Dictionary<(int, int), int> visited = [];
        visited[position] = 1;
        direction = Turn(direction);

        while (true)
        {
            var (newRow, newCol) = NextPosition(position, direction);

            if (newRow < 0 || newRow >= height || newCol < 0 || newCol >= width)
            {
                return false;
            }

            if (map[newRow][newCol] == '#')
            {
                if (visited.TryGetValue(position, out var count) && count > 1)
                {
                    return true;
                }
                else
                {
                    visited[position] = count + 1;
                }
                direction = Turn(direction);
                continue;
            }

            position = (newRow, newCol);
        }
    }

    private static string Turn(string direction)
    {
        return direction switch
        {
            "up" => "right",
            "right" => "down",
            "down" => "left",
            "left" => "up",
            _ => throw new Exception("Invalid direction")
        };
    }

    private static (int, int) NextPosition((int, int) position, string direction)
    {
        var (row, col) = position;

        return direction switch
        {
            "up" => (row - 1, col),
            "down" => (row + 1, col),
            "left" => (row, col - 1),
            "right" => (row, col + 1),
            _ => throw new Exception("Invalid direction")
        };
    }
}
