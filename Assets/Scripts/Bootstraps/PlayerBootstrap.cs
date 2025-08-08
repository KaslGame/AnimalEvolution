using CharacterSystem;
using Input;
using PlayerScripts;
using UI.PlayerUI;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace Bootstraps
{
    public class PlayerBootstrap : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private PlayerMovement _movement;
        [SerializeField] private List<CharacterData> _characters = new List<CharacterData>();
        [SerializeField] private ProgressBar _progressBar;
        [SerializeField] private PickUper _pickUper;

        [SerializeField] private float _scaleFactor = 0.1f;

        public bool IsMobile;

        private IInputController _controller;

        private void Awake()
        {
            InputInitialize();
            CharacterInitialize();
        }

        private void CharacterInitialize()
        {
            PlayerStats playerStats = new PlayerStats();
            PlayerScaler scaler = new PlayerScaler(_movement.transform, playerStats, _scaleFactor);

            List<CharacterData> sortedCharacter = _characters.OrderBy(player => player.MinLevel).ToList();

            CharacterChanger characterChanger = new CharacterChanger(playerStats, sortedCharacter, _player, scaler);

            _progressBar.Initialize(playerStats);
            _pickUper.Init(playerStats);
        }

        private void InputInitialize()
        {
            if (IsMobile)
            {
                _controller = new MobileController(_joystick);
            }
            else
            {
                PlayerInput playerInput = new PlayerInput();

                _controller = new DesktopController(playerInput);
                HideJoystick();
            }

            _movement.SetController(_controller);
        }

        private void HideJoystick()
        {
            _joystick.gameObject.SetActive(false);
        }
    }
}