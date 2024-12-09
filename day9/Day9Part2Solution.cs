namespace Aoc2024;

public class Day9Part2Solution : ISolution
{
    public long GetSolution()
    {
        var input = File.ReadAllText("day9/input")
            .Trim()
            .Select(c => c - '0')
            .ToArray();

        List<Space> drive = [];
        int[] freePositions = new int[10];

        var id = 0;
        for (int i = 0; i < input.Length; i += 2)
        {
            drive.Add(new Space(id++, input[i]));
            if (i < input.Length - 1)
            {
                if (freePositions[input[i + 1]] == 0)
                {
                    freePositions[input[i + 1]] = i + 1;
                }
                drive.Add(new Space(null, input[i + 1]));
            }
        }

        for (var i = drive.Count - 1; i >= 0; i--)
        {
            if (drive[i].Id is null || drive[i].Size == 0)
            {
                continue;
            }

            var freePos = int.MaxValue;
            var freeSlot = 0;
            for (int j = drive[i].Size; j < 10; j++)
            {
                if (freePositions[j] != 0 && freePositions[j] < freePos && freePositions[j] < i)
                {
                    freePos = freePositions[j];
                    freeSlot = j;
                }
            }

            if (freePos != int.MaxValue)
            {
                var newFreePos = freePos + 1;
                var newFreeSize = drive[freePos].Size - drive[i].Size;

                drive[freePos] = new Space(drive[i].Id, drive[i].Size);
                drive[i] = new Space(null, drive[i].Size);

                // Update free position for that size
                freePositions[freeSlot] = 0;
                for (var j = freePos + 1; j < i; j++)
                {
                    if (drive[j].Id is null && drive[j].Size == freeSlot)
                    {
                        freePositions[freeSlot] = j;
                        break;
                    }
                }

                if (newFreeSize > 0)
                {
                    drive.Insert(newFreePos, new Space(null, newFreeSize));

                    for (var j = 0; j < 10; j++)
                    {
                        if (freePositions[j] >= freePos)
                        {
                            freePositions[j]++;
                        }
                    }
                    if (newFreePos < freePositions[newFreeSize])
                    {
                        freePositions[newFreeSize] = newFreePos;
                    }
                }

            }
        }


        long checksum = 0;
        long block = 0;
        foreach (var space in drive)
        {
            for (var i = 0; i < space.Size; i++)
            {
                checksum += (space.Id ?? 0) * block++;
            }
        }

        return checksum;
    }

    private record Space(long? Id, int Size);
}
