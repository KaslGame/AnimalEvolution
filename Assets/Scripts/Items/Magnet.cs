using System;
using YG;

public class Magnet
{
    public event Action<int> OnLevelChanged;

    public int Level => YG2.saves.LevelMagnet;

    public void IncreaseLevel(int level)
    {
        if (level < 0)
            return;

        YG2.saves.LevelMagnet += level;

        OnLevelChanged?.Invoke(level);
    }
}
