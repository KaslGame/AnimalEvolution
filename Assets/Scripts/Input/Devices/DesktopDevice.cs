using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace Input
{
    public class DesktopDevice : IDevice
    {
        private const string Move = nameof(Move);
        private const string Booster = nameof(Booster);

        private List<InputAction> _actions = new List<InputAction>();

        public DesktopDevice(PlayerInputSystem input)
        {
            _actions.Add(input.Player.Move);
            _actions.Add(input.Player.Booster);
        }

        public void Disable()
        {
            foreach (var action in _actions)
                action.Disable();
        }

        public void Enable()
        {
            foreach (var action in _actions)
                action.Enable();
        }
    }
}