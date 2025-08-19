using System;
using YG;

namespace ItemScripts
{
    public class Magnet
    {
        public event Action<int> LevelChanged;

        public int Level => YG2.saves.LevelMagnet;

        public void IncreaseLevel(int level)
        {
            if (level < 0)
                return;

            YG2.saves.LevelMagnet += level;

            LevelChanged?.Invoke(level);
        }
    }
}