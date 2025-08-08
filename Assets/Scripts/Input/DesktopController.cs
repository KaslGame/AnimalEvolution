using System;
using UnityEngine;

namespace Input
{
    public class DesktopController : IInputController, IDisposable
    {
        private PlayerInput _playerInput;

        public DesktopController(PlayerInput playerInput)
        {
            _playerInput = playerInput ?? throw new ArgumentNullException(nameof(playerInput));

            _playerInput.Enable();
        }

        public Vector3 GetDirection()
        {
            Vector2 direction = _playerInput.Player.Move.ReadValue<Vector2>();

            return new Vector3(direction.x, 0, direction.y);
        }

        public void Dispose()
        {
            _playerInput.Disable();
        }
    }
}