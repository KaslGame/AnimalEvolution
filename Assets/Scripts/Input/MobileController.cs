using UnityEngine;

namespace Input
{
    public class MobileController : InputController
    {
        [SerializeField] private Joystick _joystick;

        protected override void ReadMove()
        {
            ChangeDirection(_joystick.Direction);
        }
    }
}