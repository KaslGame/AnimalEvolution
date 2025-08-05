using UnityEngine;

namespace Input
{
    public class PCController : InputController
    {
        private PlayerInput _playerInput;

        private void Awake()
        {
            _playerInput = new PlayerInput();
        }

        private void OnEnable()
        {
            _playerInput.Enable();
        }

        private void OnDisable()
        {
            _playerInput.Disable();
        }

        protected override void ReadMove()
        {
            ChangeDirection(_playerInput.Player.Move.ReadValue<Vector2>());
        }
    }
}