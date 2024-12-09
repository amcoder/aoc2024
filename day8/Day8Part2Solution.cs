namespace Aoc2024;

public class Day8Part2Solution : ISolution
{
    public long GetSolution()
    {
        var input = File.ReadLines("day8/input")
            .Select(l => l.ToCharArray())
            .ToArray();

        var width = input[0].Length;
        var height = input.Length;

        // Load the anntannas into a dictionary
        var antennas = new Dictionary<char, List<(int, int)>>();
        for (var row = 0; row < input.Length; row++)
        {
            for (var col = 0; col < input[row].Length; col++)
            {
                if (input[row][col] != '.')
                {
                    if (antennas.TryGetValue(input[row][col], out var locations))
                    {
                        locations.Add((row, col));
                    }
                    else
                    {
                        antennas.Add(input[row][col], [(row, col)]);
                    }
                }
            }
        }

        HashSet<(int, int)> antinodes = [];

        foreach (var (antenna, locations) in antennas)
        {
            for (var i = 0; i < locations.Count; i++)
            {
                for (var j = i + 1; j < locations.Count; j++)
                {
                    var (row1, col1) = locations[i];
                    var (row2, col2) = locations[j];
                    var diffrow = row2 - row1;
                    var diffcol = col2 - col1;

                    for (int r = row1, c = col1; r < height && r >= 0 && c < width && c >= 0; r -= diffrow, c -= diffcol)
                    {
                        antinodes.Add((r, c));
                    }

                    for (int r = row2, c = col2; r >= 0 && r < height && c >= 0 && c < width; r += diffrow, c += diffcol)
                    {
                        antinodes.Add((r, c));
                    }
                }
            }
        }

        return antinodes.Count;
    }
}
