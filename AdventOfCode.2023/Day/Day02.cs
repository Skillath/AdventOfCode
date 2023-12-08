namespace AdventOfCode2023.Day;

public sealed partial class Day02 : DayBase
{
    private enum Color : int
    {
        Red = 0,
        Green = 1,
        Blue = 2,
    }

    private readonly record struct Set(Color Color, int Amount);

    private static readonly IReadOnlyDictionary<string, Color> ColorMap = new Dictionary<string, Color>
    {
        { "red", Color.Red }, { "green", Color.Green }, { "blue", Color.Blue },
    };

    private Dictionary<int, Set[]> _inputs = new Dictionary<int, Set[]>();
    
    protected override void AfterConstruct()
    {
        base.AfterConstruct();

        _inputs = Inputs.ToDictionary(GetGameId, GetSet)!;
    }

    private static int GetGameId(string input)
    {
        if (string.IsNullOrEmpty(input))
            return -1;
        
        //TODO: regex this
        input = input.Split(":").First().Replace("Game ", "");
        return int.Parse(input);
    }

    private static Set[]? GetSet(string input)
    {
        //Todo regex this
        if (string.IsNullOrEmpty(input))
            return null;

        var setsRaw = input
            .Split(":")
            .Last()
            .Split("; ");

        var sets = new List<Set>();
        foreach (var setRaw in setsRaw)
        {
            var cubes = setRaw.Split(", ");
            sets.AddRange(cubes.Select(cube => new Set(ColorMap[cube.Split(" ").Last()], int.Parse(cube.Split(" ").First())))
                .ToArray());
        }

        return sets.ToArray();
    }

    public override ValueTask<string> Solve_1()
    {
        return new(string.Empty);
    }

    public override ValueTask<string> Solve_2()
    {
        return new(string.Empty);
    }
}