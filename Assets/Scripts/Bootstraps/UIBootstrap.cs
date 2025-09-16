using CharacterSystem;
using ItemScripts;
using PlayerScripts;
using System;
using System.Collections;
using UI.Menu;
using UI.PlayerUI;
using UnityEngine;

namespace Bootstraps
{
    public class UIBootstrap : Bootstrap
    {
        [SerializeField] private StandartBar _standartBar;
        [SerializeField] private CharacterBar _characterBar;
        [SerializeField] private CoinView _view;
        [SerializeField] private RewardMenu _rewardMenu;

        private IPlayerStats _stats;
        private ICoinStorage _storage;
        private ICharacterChanger _changer;
        private ILevelRewarder _rewarder;

        public void Initialize(IPlayerStats stats, ICharacterChanger changer, ICoinStorage storage, ILevelRewarder rewarder)
        {
            _stats = stats ?? throw new ArgumentNullException(nameof(stats));
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
            _changer = changer ?? throw new ArgumentNullException(nameof(changer));
            _rewarder = rewarder ?? throw new ArgumentNullException(nameof(rewarder));
        }

        public override IEnumerator Load()
        {
            _standartBar.Initialize(_stats);
            _characterBar.Initialize(_stats);
            _characterBar.Initialize(_changer);
            _view.Initialize(_storage);
            _rewardMenu.SetRewarder(_rewarder);

            yield return null;
        }
    }
}
