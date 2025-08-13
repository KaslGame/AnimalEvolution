using System;
using UnityEngine;

namespace Input
{
    public class DesktopController : IInputController, ISubscribable
    {
        private PlayerInputSystem _playerInput;

        public DesktopController(PlayerInputSystem playerInput)
        {
            _playerInput = playerInput ?? throw new ArgumentNullException(nameof(playerInput));
        }

        public event Action BoosterButtonPerformed;

        public Vector3 GetDirection()
        {
            Vector2 direction = _playerInput.Player.Move.ReadValue<Vector2>();

            return new Vector3(direction.x, 0, direction.y);
        }

        public void Subscribe()
        {
            _playerInput.Enable();

            _playerInput.Player.Booster.performed += OnBusterPerformed;
        }

        public void Unsubscribe()
        {
            _playerInput.Player.Booster.performed -= OnBusterPerformed;

            _playerInput.Disable();
        }

        private void OnBusterPerformed(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            BoosterButtonPerformed?.Invoke();
        }
    }
}