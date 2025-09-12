using ItemScripts;
using UnityEngine;
using System;

public class PlayerSoundHandler : MonoBehaviour
{
    private ICoinStorage _storage;

    public void Initialize(ICoinStorage storage)
    {
        _storage = storage ?? throw new ArgumentNullException(nameof(storage));
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
}
