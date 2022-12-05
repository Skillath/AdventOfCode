namespace AdventOfCode;

public static class StringExtensions
{
    public static IEnumerable<string> SplitInput(this string input) => input.Split(Environment.NewLine);
}