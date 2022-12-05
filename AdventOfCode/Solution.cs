using System.Text;

namespace AdventOfCode;

public readonly struct Solution
{
    public uint Day { get; }
    public string Part1 { get; }
    public string Part2 { get; }

    public Solution(
        uint day,
        string part1,
        string part2)
    {
        Day = day;
        Part1 = part1;
        Part2 = part2;
    }

    public void Deconstruct(
        out uint day,
        out string part1,
        out string part2)
    {
        day = Day;
        part1 = Part1;
        part2 = Part2;
    }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder()
            .AppendLine($"Day {Day}")
            .AppendLine($"\tPart 1:\n\t{Part1}")
            .AppendLine($"\tPart 2:\n\t{Part2}");

        return stringBuilder.ToString();
    }
}