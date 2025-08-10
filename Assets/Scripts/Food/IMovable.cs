using System;
using UnityEngine;

namespace FoodScripts
{
    public interface IMovable
    {
        void SetTarget(Transform target);
        event Action<IEdible> TargetReached;
    }
}