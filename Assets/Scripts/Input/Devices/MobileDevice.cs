using System;
using UnityEngine.UI;

namespace Input
{
    public class MobileDevice : IDevice
    {
        private Joystick _joystick;
        private Button _boosterButton;

        public MobileDevice(Joystick joystick, Button boosterButton)
        {
            _joystick = joystick ?? throw new ArgumentNullException(nameof(joystick));
            _boosterButton = boosterButton ?? throw new ArgumentNullException(nameof(boosterButton));
        }

        public void Disable()
        {
            bool diasble = false;

            _joystick.gameObject.SetActive(diasble);
            _boosterButton.gameObject.SetActive(diasble);
        }

        public void Enable()
        {
            bool enable = true;

            _joystick.gameObject.SetActive(enable);
            _boosterButton.gameObject.SetActive(enable);
        }
    }

}