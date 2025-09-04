using System;
using UnityEngine;

namespace CharacterSystem
{
    public interface IFormChanger
    {
        event Action<Animator> FormChanged;
    }
}