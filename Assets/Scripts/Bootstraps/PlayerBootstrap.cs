using CharacterSystem;
using PlayerScripts;
using System;
using System.Collections;
using UnityEngine;

namespace Bootstraps
{
    public class PlayerBootstrap : Bootstrap
    {
        [SerializeField] private BoosterBoostrap _boosterBootstrap;
        [SerializeField] private FormApplier _applier;
        [SerializeField] private PlayerAnimations _animations;
        [SerializeField] private Player _player;

        private PlayerStats _playerStats;
        private EvolutionService _changer;

        public void Initialize(EvolutionService changer, PlayerStats stats)
        {
            _changer = changer ?? throw new ArgumentNullException(nameof(changer));
            _playerStats = stats ?? throw new ArgumentNullException(nameof(stats));
        }

        public override IEnumerator Load()
        {
            _boosterBootstrap.Initialize(_playerStats, _changer);
            _player.Initialize(_playerStats);
            _animations.Initialize(_playerStats);

            yield return _boosterBootstrap.Load();
        }
    }
}