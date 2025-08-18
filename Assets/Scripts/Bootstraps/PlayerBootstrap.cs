using CameraScripts;
using CharacterSystem;
using CommonInterfaces;
using PlayerScripts;
using System.Collections.Generic;
using UI.PlayerUI;
using UnityEngine;

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

        private PlayerStats _playerStats;
        private EvolutionService _changer;

        private List<ISubscribable> _subscribables = new();

        private void Awake()
        {
            PlayerInitialize();

            _standartBar.Initialize(_playerStats);
            _characterBar.Initialize(_playerStats);
            _characterBar.Initialize(_changer);
            _cameraPersuer.Initialize(_player, _playerStats);
            _foodBootstrap.Initialize(_playerStats, _player);
            _boosterBootstrap.Initialize(_playerStats, _changer);
        }

        private void Start()
        {
            int costFirstLevel = 0;

            _playerStats.AddScore(costFirstLevel);
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
    }
}