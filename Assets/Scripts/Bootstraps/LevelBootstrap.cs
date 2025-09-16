using CharacterSystem;
using CommonInterfaces;
using ItemScripts;
using PlayerScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bootstraps
{
    public class LevelBootstrap : Bootstrap
    {
        private const int RewardPerLevel = 5;

        [Header("Level Settings")]
        [SerializeField] private EvolutionConfig _config;

        [Header("Other Settings")]
        [SerializeField] private PlayerBootstrap _player;
        [SerializeField] private FoodBootstrap _food;
        [SerializeField] private UIBootstrap _ui;
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private FormApplier _applier;

        private List<Bootstrap> _bootstraps = new List<Bootstrap>();
        private List<ISubscribable> _subscribables = new();
        private PlayerStats _playerStats;

        private void OnDisable()
        {
            UnSubscribe();
        }

        public override IEnumerator Load()
        {
            var storage = new CoinStorage();
            _playerStats = new PlayerStats();
            var changer = new EvolutionService(_config, _applier, _playerStats);
            var rewarder = new LevelRewarder(_playerStats, storage, RewardPerLevel);

            _subscribables.Add(changer);
            _subscribables.Add(rewarder);

            Subscribe();

            _player.Initialize(changer, _playerStats);
            _food.Initialize(_playerStats, _playerTransform);
            _ui.Initialize(_playerStats, changer, storage, rewarder);

            yield return LoadBootstraps();

            StartGame();
        }

        private IEnumerator LoadBootstraps()
        {
            _bootstraps.Add(_player);
            _bootstraps.Add(_food);
            _bootstraps.Add(_ui);

            foreach (var bootstrap in _bootstraps)
                yield return StartCoroutine(bootstrap.Load());
        }

        private void Subscribe()
        {
            foreach (ISubscribable subscribable in _subscribables)
                subscribable.Subscribe();
        }

        private void UnSubscribe()
        {
            foreach (ISubscribable subscribable in _subscribables)
                subscribable.Unsubscribe();
        }

        private void StartGame()
        {
            int firstLevel = 0;

            _playerStats.AddScore(firstLevel);
        }
    }
}