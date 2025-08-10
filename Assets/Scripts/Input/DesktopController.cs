using System;
using UnityEngine;

namespace Input
{
    public class DesktopController : IInputController, ISubscribable
    {
        private PlayerInput _playerInput;

        public DesktopController(PlayerInput playerInput)
        {
            _playerInput = playerInput ?? throw new ArgumentNullException(nameof(playerInput));
        }

        public event Action ButtonPerformed;

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
            ButtonPerformed?.Invoke();
        }
    }
}