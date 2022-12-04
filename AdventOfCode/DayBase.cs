namespace AdventOfCode;

public abstract class DayBase : IPuzzle
{
    protected uint Day { get; }

    protected DayBase(uint day)
    {
        Day = day;
    }

    public abstract Solution Solve();
}