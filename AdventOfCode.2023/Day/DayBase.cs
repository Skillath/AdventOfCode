using AoCHelper;

namespace AdventOfCode2023.Day;

public abstract class DayBase : BaseDay
{
    protected IEnumerable<string> Inputs { get; }
    
    protected DayBase() : base()
    {
        Inputs = File.ReadAllLines(InputFilePath);
    }
}