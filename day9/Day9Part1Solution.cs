namespace Aoc2024;

public class Day9Part1Solution : ISolution
{
    public long GetSolution()
    {
        var input = File.ReadAllText("day9/input")
            .Trim()
            .Select(c => c - '0')
            .ToArray();

        long id = 0;
        long endid = input.Length / 2;

        long block = 0;
        long checksum = 0;
        int pos;
        int end;
        for (pos = 0, end = input.Length - 1; pos <= end; pos += 2)
        {
            for (var i = 0; i < input[pos]; i++)
            {
                checksum += id * block++;
            }

            if (pos == end)
            {
                break;
            }

            var free = input[pos + 1];
            while (free > 0)
            {
                if (input[end] == 0)
                {
                    end -= 2;
                    endid--;
                    continue;
                }

                checksum += endid * block++;
                input[end] -= 1;
                free--;
            }

            id++;
        }

        return checksum;
    }
}
