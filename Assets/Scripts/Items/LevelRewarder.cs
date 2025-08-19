using CommonInterfaces;
using System;
using UnityEngine;

namespace ItemScripts
{
    public class LevelRewarder : ISubscribable
    {
        private const int FirstLevel = 1;

        private readonly IPlayerStats _stats;
        private readonly ICoinIncreaser _increaser;

        private int _rewardPerLevel;

        public LevelRewarder(IPlayerStats stats, ICoinIncreaser increaser, int rewardPerLevel)
        {
            if (rewardPerLevel < 0)
                throw new ArgumentOutOfRangeException(nameof(rewardPerLevel));

            _stats = stats ?? throw new ArgumentNullException(nameof(stats));
            _increaser = increaser ?? throw new ArgumentNullException(nameof(increaser));
            _rewardPerLevel = rewardPerLevel;
        }

        public void Subscribe()
        {
            _stats.LevelChanged += OnLevelChanged;
        }

        public void Unsubscribe()
        {
            _stats.LevelChanged -= OnLevelChanged;
        }

        private void OnLevelChanged(int level)
        {
            int reward = level * _rewardPerLevel;

            if (level <= FirstLevel)
                return;

            _increaser.Increase(reward);
        }
    }
}
