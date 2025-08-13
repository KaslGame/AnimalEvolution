using BoostersScripts;
using Input;
using System;
using UnityEngine;

public class BoosterBoostrap : MonoBehaviour
{
    [SerializeField] private MagnetBooster _magnet;

    private IPlayerStats _stats;

    public void SetInputController(IInputController controller)
    {
        _magnet.SetInputController(controller);
    }

    public void SetPlayerStats(IPlayerStats stats)
    {
        int level = 1; // YG2.saves.LevelMagnet

        _stats = stats ?? throw new ArgumentNullException(nameof(stats));
        _magnet.ZoneInitialize(level, _stats);
    }
}
