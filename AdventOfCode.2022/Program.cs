using AdventOfCode;
using AdventOfCode_2022.Days;

var days = new IPuzzle[]
{
    new Day1(1), new Day2(2),
};

var results = await Task.Run(() =>
    days.Select(d => d.Solve())
        .OrderBy(d => d.Day)
        .ToArray());

foreach (var result in results)
{
    Console.WriteLine(result.ToString());
}
