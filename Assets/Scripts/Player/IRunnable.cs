using System;

public interface IRunnable
{
    event Action<bool> RunningConditionChanged;

    bool IsRun { get; }
}
