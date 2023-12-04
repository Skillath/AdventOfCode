using System.Text.RegularExpressions;

namespace AdventOfCode2023.Day;

public sealed partial class Day01 : DayBase
{
    [GeneratedRegex(@"(?:one|two|three|four|five|six|seven|eight|nine|\d)")]
    private static partial Regex MyRegex();

    public override ValueTask<string> Solve_1()
    {
        var result = 0;
        foreach (var input in Inputs)
        {
            var firstIntAsString = input.FirstOrDefault(char.IsNumber);
            var lastIntAsString = input.LastOrDefault(char.IsNumber);
            
            var numberAsString = string.Concat(firstIntAsString, lastIntAsString);
            if (!int.TryParse(numberAsString, out var number))
                continue;

            result += number;
        }

        return new(result.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var numbersSpelledOut = new Dictionary<string, string>
        {
            { "one", "1" }, 
            { "two", "2" }, 
            { "three", "3" }, 
            { "four", "4" }, 
            { "five", "5" }, 
            { "six", "6" }, 
            { "seven", "7" }, 
            { "eight", "8" }, 
            { "nine", "9" },
        };

        var result = 0;
        foreach (var input in Inputs)
        {
            var matches = MyRegex()
                .Matches(input);

            var numbers = new List<string>();
            foreach (Match match in matches)
            {
                var value = match.Value;
                if (int.TryParse(match.Value, out _))
                {
                    numbers.Add(value);
                    continue;
                }

                if (numbersSpelledOut.TryGetValue(value, out var num))
                {
                    numbers.Add(num);
                    continue;
                }
            }

            if(!numbers.Any())
                continue;
            
            var firstIntAsString = numbers.First();
            var lastIntAsString = numbers.Last();


            var numberAsString = string.Concat(firstIntAsString, lastIntAsString);
            if (!int.TryParse(numberAsString, out var number))
                continue;

            result += number;
        }

        return new(result.ToString());
    }
}