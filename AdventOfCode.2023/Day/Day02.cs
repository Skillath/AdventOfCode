using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace AdventOfCode2023.Day;

[UsedImplicitly]
public sealed partial class Day02 : DayBase
{
    private enum Color
    {
        Red = 0,
        Green = 1,
        Blue = 2
    }

    private readonly record struct Set(Color Color, int Amount);

    private readonly record struct Game(int Id, Set[] Sets);

    private static readonly IReadOnlyDictionary<string, Color> ColorMap = new Dictionary<string, Color>
    {
        { "red", Color.Red }, { "green", Color.Green }, { "blue", Color.Blue }
    };

    private Game[] _games;


    [GeneratedRegex(@"Game (\d+):")]
    private static partial Regex GetGameIdRegex();

    [GeneratedRegex(@"(\d+) (blue|red|green)")]
    private static partial Regex GetGameSetsRegex();

    protected override void AfterConstruct()
    {
        base.AfterConstruct();
        _games = ParseGames(Inputs);
    }

    private static Game[] ParseGames(IEnumerable<string> inputs)
    {
        return inputs
            .Select(ParseGame)
            .Where(game => game.HasValue)
            .Select(game => game!.Value)
            .ToArray();
    }

    private static Game? ParseGame(string input)
    {
        var gameIdMatch = GetGameIdRegex()
            .Match(input);

        if (!gameIdMatch.Success)
            return null;

        var gameId = int.Parse(gameIdMatch.Groups[1].Value);

        var setsMatches = GetGameSetsRegex().Matches(input);
        if (setsMatches.Count == 0)
            return null;

        var sets = setsMatches
            .Select(match =>
            {
                var quantity = int.Parse(match.Groups[1].Value);
                var color = ColorMap[match.Groups[2].Value];
                return new Set(color, quantity);
            })
            .ToArray();

        return new Game(gameId, sets);
    }

    public override ValueTask<string> Solve_1()
    {
        var winConditions = new Dictionary<Color, int>
        {
            { Color.Red, 12 },
            { Color.Green, 13 },
            { Color.Blue, 14 }
        };

        // TODO: this can be optimized a bit more like in the second part
        var inputs = _games
            .Select(input => (input.Id, Sets: input.Sets
                .GroupBy(sets => sets.Color)
                .ToDictionary(game => game.Key, game => game.ToArray())));

        var result = 0;
        foreach (var (id, sets) in inputs)
        {
            if (!sets.All(game => game.Value.All(set => set.Amount <= winConditions[set.Color])))
                continue;

            result += id;
        }

        return new(result.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var result = _games
            .Sum(input => input.Sets
                .GroupBy(game => game.Color)
                .Select(game => game.MaxBy(g => g.Amount).Amount)
                .Aggregate((left, right) => left * right));

        return new(result.ToString());
    }
}