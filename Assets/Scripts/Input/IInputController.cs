using System;
using UnityEngine;

namespace Input
{
    public interface IInputController
    {
        event Action BoosterButtonPerformed;
        Vector3 GetDirection();
    }
}
