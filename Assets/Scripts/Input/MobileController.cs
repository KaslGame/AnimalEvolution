using System;
using UnityEngine;

namespace Input
{
    public class MobileController : IInputController
    {
        private Joystick _joystick;

        public MobileController(Joystick joystick)
        {
            _joystick = joystick ?? throw new ArgumentNullException(nameof(joystick));
        }

        public Vector3 GetDirection()
        {
            return new Vector3(_joystick.Direction.x, 0, _joystick.Direction.y);
        }
    }
}