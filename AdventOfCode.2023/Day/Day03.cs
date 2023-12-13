using System.Text;
using JetBrains.Annotations;

namespace AdventOfCode2023.Day;

[UsedImplicitly]
public sealed class Day03 : DayBase
{
    private readonly record struct Point(int X, int Y);
    
    public override ValueTask<string> Solve_1()
    {
        var map = new Dictionary<Point, string>();
        
        var inputs = Inputs.ToArray();
        for (var i = 0; i < inputs.Length; i++)
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

                if (character is not ('#' or '$' or '*' or '+')) 
                    continue;
                
                map.Add(new Point(j, i), character.ToString());
            }
        }

        
        
        return new("");
    }

    public override ValueTask<string> Solve_2()
    {
        return new("");
    }
}