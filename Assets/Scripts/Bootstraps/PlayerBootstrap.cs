using CharacterSystem;
using Input;
using PlayerScripts;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace Bootstraps
{
    public class PlayerBootstrap : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private List<CharacterData> _characters = new List<CharacterData>();
        [SerializeField] private ProgressBar _progressBar;
        [SerializeField] private PickUper _pickUper;
        [SerializeField] private FoodBootstrap _foodBootstrap;

        [SerializeField] private float _scaleFactor = 0.1f;

        private PlayerStats _playerStats;

        private void Awake()
        {
            CharacterInitialize();

            _foodBootstrap.Initialize(_playerStats, _player.transform);
        }

        private void CharacterInitialize()
        {
            _playerStats = new PlayerStats();
            PlayerScaler scaler = new PlayerScaler(_player.transform, _playerStats, _scaleFactor);

            List<CharacterData> sortedCharacter = _characters.OrderBy(player => player.MinLevel).ToList();

            CharacterChanger characterChanger = new CharacterChanger(_playerStats, sortedCharacter, _player, scaler);

            _progressBar.Initialize(_playerStats);
            _pickUper.Init(_playerStats);
        }
    }
}