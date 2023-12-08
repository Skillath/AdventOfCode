using System.Runtime.InteropServices.JavaScript;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace AdventOfCode2023.Day;

[UsedImplicitly]
public sealed class Day01 : DayBase
{
    public override ValueTask<string> Solve_1()
    {
        var result = 0;
        foreach (var input in Inputs)
        {
            if (!GetValueFromInputLine(input, out var number))
                continue;

            result += number;
        }

        return new(result.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var numbersSpelledOut = new Dictionary<string, string>
        {
            { "one", "o1e" }, 
            { "two", "t2o" }, 
            { "three", "th3ee" }, 
            { "four", "fo4ur" }, 
            { "five", "fi5ve" }, 
            { "six", "s6x" }, 
            { "seven", "se7en" }, 
            { "eight", "ei8ht" }, 
            { "nine", "ni9ne" },
        };
        
        var result = 0;
        foreach (var i in Inputs)
        {
            var input = i;
            foreach (var (key, value) in numbersSpelledOut)
            {
                input = input.Replace(key, value);
            }
            
            if (!GetValueFromInputLine(input, out var number)) 
                continue;

            result += number;
        }

        return new(result.ToString());
    }

    private static bool GetValueFromInputLine(string input, out int number)
    {
        number = 0;
        input = new string(input.Where(char.IsNumber).ToArray());
        if (string.IsNullOrEmpty(input))
            return false;
        
        var firstIntAsString = input[0];
        var lastIntAsString = input[^1];

        var numberAsString = string.Concat(firstIntAsString, lastIntAsString);

        return int.TryParse(numberAsString, out number);
    }
}