namespace Aoc2024;

public class Day8Part1Solution : ISolution
{
    public long GetSolution()
    {
        var input = File.ReadLines("Day08/input")
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

                    var anrow1 = row1 - (row2 - row1);
                    var ancol1 = col1 - (col2 - col1);
                    if (anrow1 >= 0 && anrow1 < height && ancol1 >= 0 && ancol1 < width)
                    {
                        antinodes.Add((anrow1, ancol1));
                    }

                    var anrow2 = row2 + (row2 - row1);
                    var ancol2 = col2 + (col2 - col1);
                    if (anrow2 >= 0 && anrow2 < height && ancol2 >= 0 && ancol2 < width)
                    {
                        antinodes.Add((anrow2, ancol2));
                    }
                }
            }
        }

        return antinodes.Count;
    }
}
