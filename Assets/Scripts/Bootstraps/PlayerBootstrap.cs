using CameraScripts;
using CharacterSystem;
using CommonInterfaces;
using PlayerScripts;
using System.Collections.Generic;
using UI.PlayerUI;
using UnityEngine;
using ItemScripts;

namespace Bootstraps
{
    public class PlayerBootstrap : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private GameObject _playerModel;

        [SerializeField] private StandartBar _standartBar;
        [SerializeField] private CharacterBar _characterBar;

        [SerializeField] private FoodBootstrap _foodBootstrap;
        [SerializeField] private BoosterBoostrap _boosterBootstrap;
        [SerializeField] private CameraPursuer _cameraPersuer;

        [SerializeField] private EvolutionConfig _config;
        [SerializeField] private FormApplier _applier;

        [SerializeField] private float _scaleFactor = 0.1f;

        [SerializeField] private int _rewardPerLevel;
        [SerializeField] private CoinView _coinView;

        private PlayerStats _playerStats;
        private EvolutionService _changer;
        private CoinStorage _storage;

        private List<ISubscribable> _subscribables = new();

        private void Awake()
        {
            PlayerInitialize();
            CoinsInitialize();

            _standartBar.Initialize(_playerStats);
            _characterBar.Initialize(_playerStats);
            _characterBar.Initialize(_changer);
            _cameraPersuer.Initialize(_player, _playerStats);
            _foodBootstrap.Initialize(_playerStats, _player);
            _boosterBootstrap.Initialize(_playerStats, _changer);
        }

        private void Start()
        {
            int firstLevel = 0;

            _playerStats.AddScore(firstLevel);
        }

        private void OnEnable()
        {
            foreach (ISubscribable subscribable in _subscribables)
                subscribable.Subscribe();
        }

        private void OnDisable()
        {
            foreach (ISubscribable subscribable in _subscribables)
                subscribable.Unsubscribe();
        }

        private void PlayerInitialize()
        {
            _playerStats = new PlayerStats();
            PlayerScaler scaler = new(_player.transform, _playerStats, _scaleFactor);
            _changer = new EvolutionService(_config, _applier, _playerStats);

            _subscribables.Add(_changer);
        }

        private void CoinsInitialize()
        {
            CoinStorage storage = new CoinStorage();
            LevelRewarder rewarder = new LevelRewarder(_playerStats, storage, _rewardPerLevel);

            _coinView.Initialize(storage);
            _subscribables.Add(rewarder);

            _storage = storage;
        }
    }
}