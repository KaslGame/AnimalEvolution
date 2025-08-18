using System;

public interface IPlayerStats
{
    event Action<float, float> ScoreChanged;
    event Action<int> LevelChanged;
    int Level { get; }
    float TotalScore { get; }
    float BasePointsPerLevel { get; }
}
