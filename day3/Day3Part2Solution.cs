namespace Aoc2024;

public class Day3Part2Solution : ISolution
{
    public long GetSolution()
    {
        var input = File.ReadAllText("day3/input");

        var op1 = 0;
        var op2 = 0;
        var result = 0;
        var enabled = true;

        var state = "scan";

        foreach (var c in input)
        {
            switch (state)
            {
                case "scan":
                    state = enabled && c == 'm' ? "m" : c == 'd' ? "d" : "scan";
                    break;
                case "m":
                    state = c == 'u' ? "u" : "scan";
                    break;
                case "u":
                    state = c == 'l' ? "l" : "scan";
                    break;
                case "d":
                    state = c == 'o' ? "o" : "scan";
                    break;
                case "o":
                    state = c == 'n' ? "n" : c == '(' ? "do" : "scan";
                    break;
                case "n":
                    state = c == '\'' ? "'" : "scan";
                    break;
                case "'":
                    state = c == 't' ? "t" : "scan";
                    break;
                case "t":
                    state = c == '(' ? "dont" : "scan";
                    break;
                case "do":
                    if (c == ')')
                    {
                        enabled = true;
                    }
                    state = "scan";
                    break;
                case "dont":
                    if (c == ')')
                    {
                        enabled = false;
                    }
                    state = "scan";
                    break;
                case "l":
                    if (c == '(')
                    {
                        state = "op1";
                        op1 = 0;
                    }
                    else
                    {
                        state = "scan";
                    }
                    break;
                case "op1":
                    if (char.IsDigit(c))
                    {
                        op1 = (op1 * 10) + c - '0';
                    }
                    else if (c == ',')
                    {
                        state = "op2";
                        op2 = 0;
                    }
                    else
                    {
                        state = "scan";
                    }
                    break;
                case "op2":
                    if (char.IsDigit(c))
                    {
                        op2 = (op2 * 10) + c - '0';
                    }
                    else if (c == ')')
                    {
                        result += op1 * op2;
                        state = "scan";
                    }
                    else
                    {
                        state = "scan";
                    }
                    break;
            }
        }

        return result;
    }
}
