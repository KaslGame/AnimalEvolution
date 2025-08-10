using System;
using UnityEngine;

namespace Input
{
    public interface IInputController
    {
        event Action ButtonPerformed;
        Vector3 GetDirection();
    }
}
