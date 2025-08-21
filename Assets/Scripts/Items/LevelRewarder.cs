using CommonInterfaces;
using System;
using YG;

namespace ItemScripts
{
    public class LevelRewarder : ISubscribable, ILevelRewarder
    {
        private const string RewardID = "Coins";
        private const int FirstLevel = 1;

        private readonly IPlayerStats _stats;
        private readonly ICoinIncreaser _increaser;
        private readonly int _rewardPerLevel;

        public int TotalReward { get; private set; }

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
            YG2.onRewardAdv += OnReward;
        }

        public void Unsubscribe()
        {
            _stats.LevelChanged -= OnLevelChanged;
            YG2.onRewardAdv -= OnReward;
        }

        private void OnLevelChanged(int level)
        {
            int reward = level * _rewardPerLevel;

            if (level <= FirstLevel)
                return;

            IncreaseCoint(reward);
        }

        private void OnReward(string id)
        {
            if (id == RewardID)
                return;

            IncreaseCoint(TotalReward);
        }

        private void IncreaseCoint(int amount)
        {
            if (amount < 0)
                return;

            TotalReward += amount;
            _increaser.Increase(amount);
        }
    }
}
