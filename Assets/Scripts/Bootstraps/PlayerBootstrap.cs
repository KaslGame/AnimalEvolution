using CharacterSystem;
using PlayerScripts;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using CameraScripts;

namespace Bootstraps
{
    public class PlayerBootstrap : MonoBehaviour
    {
        [SerializeField] private GameObject _playerModel;
        [SerializeField] private List<CharacterData> _characters = new List<CharacterData>();
        [SerializeField] private ProgressBar _progressBar;
        [SerializeField] private PickUper _pickUper;
        [SerializeField] private FoodBootstrap _foodBootstrap;
        [SerializeField] private BoosterBoostrap _boosterBootstrap;
        [SerializeField] private CameraPursuer _cameraPersuer;

        [SerializeField] private float _scaleFactor = 0.1f;

        private PlayerStats _playerStats;

        private void Awake()
        {
            CharacterInitialize();

            _cameraPersuer.Initialize(_playerModel.transform, _playerStats);
            _foodBootstrap.Initialize(_playerStats, _playerModel.transform);
            _boosterBootstrap.SetPlayerStats(_playerStats);
        }

        private void CharacterInitialize()
        {
            _playerStats = new PlayerStats();
            PlayerScaler scaler = new PlayerScaler(_playerModel.transform, _playerStats, _scaleFactor);

            List<CharacterData> sortedCharacter = _characters.OrderBy(player => player.MinLevel).ToList();

            CharacterChanger characterChanger = new CharacterChanger(_playerStats, sortedCharacter, _playerModel, scaler);

            _progressBar.Initialize(_playerStats);
            _pickUper.Init(_playerStats);
        }
    }
}