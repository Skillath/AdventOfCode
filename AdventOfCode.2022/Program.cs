using AdventOfCode;
using AdventOfCode_2022.Days;

var days = new IPuzzle[]
{
    new Day1(), new Day2(), new Day3(),
};

var results = await Task.Run(() =>
    days.Select(d => d.Solve())
        .OrderBy(d => d.Day)
        .ToArray());

Console.WriteLine();
Console.Write(@" / \---------------------------, 
 \_,|                          | 
    |    Advent of Code 2022   | 
    |  ,-------------------------
    \_/________________________/ ");

Console.WriteLine();
Console.WriteLine();

foreach (var result in results)
{
    Console.WriteLine(result.ToString());
}
