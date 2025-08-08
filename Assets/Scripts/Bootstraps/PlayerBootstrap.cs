using Input;
using PlayerScripts;
using UnityEngine;

namespace Bootstraps
{
    public class PlayerBootstrap : MonoBehaviour
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private PlayerMovement _movement;

        public bool IsMobile;

        private IInputController _controller;

        private void Awake()
        {
            InputInitialize();
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