namespace AdventOfCode;

public interface IPuzzle
{
    uint Day { get; }

    Solution Solve();
}