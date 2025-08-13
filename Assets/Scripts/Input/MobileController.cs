using System;
using UnityEngine;
using UnityEngine.UI;

namespace Input
{
    public class MobileController : IInputController, ISubscribable
    {
        private Joystick _joystick;
        private Button _button;

        public MobileController(Joystick joystick, Button boosterButton)
        {
            _joystick = joystick ?? throw new ArgumentNullException(nameof(joystick));
            _button = boosterButton ?? throw new ArgumentNullException(nameof(boosterButton));
        }

        public event Action BoosterButtonPerformed;

        public Vector3 GetDirection()
        {
            return new Vector3(_joystick.Direction.x, 0, _joystick.Direction.y);
        }

        public void Subscribe()
        {
            _button.onClick.AddListener(OnBoosterPerformed);
        }

        public void Unsubscribe()
        {
            _button.onClick.RemoveListener(OnBoosterPerformed);
        }

        private void OnBoosterPerformed()
        {
            BoosterButtonPerformed?.Invoke();
        }
    }
}