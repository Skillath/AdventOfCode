using System.Text;
using JetBrains.Annotations;

namespace AdventOfCode2023.Day;

[UsedImplicitly]
public sealed class Day03 : DayBase
{
    private const string Symbols = "$&+*";
    
    private readonly record struct Point(int X, int Y);
    
    private static Dictionary<Point, string> MapInput(IReadOnlyList<string> inputs)
    {
        var map = new Dictionary<Point, string>();
        
        for (var i = 0; i < inputs.Count; i++)
        {
            var input = inputs[i];
            var numberBuilder = new StringBuilder();
            for (int j = 0; j < input.Length; j++)
            {
                var character = input[j];
                if (char.IsNumber(character))
                {
                    numberBuilder.Append(character);   
                    continue;
                }

                if (numberBuilder.Length > 0)
                {
                    map.Add(new Point(j - numberBuilder.Length, i), numberBuilder.ToString());
                }
                
                numberBuilder.Clear();
                
                if(character is '.')
                    continue;

                if(!Symbols.Contains(character)) 
                    continue;
                
                map.Add(new Point(j, i), character.ToString());
            }
        }

        return map;
    }
    
    public override ValueTask<string> Solve_1()
    {
        var map = MapInput(Inputs.ToArray());

        var symbolPositions = map
            .Where(item => Symbols.Contains(item.Value))
            .Select(item => item.Key);

        foreach (var symbolPosition in symbolPositions)
        {
            
        }
        
        return new("");
    }
    
    public override ValueTask<string> Solve_2()
    {
        return new("");
    }
}