using BoostersScripts;
using CharacterSystem;
using Input;
using System;
using UnityEngine;

public class BoosterBoostrap : MonoBehaviour
{
    [SerializeField] private MagnetBooster _magnet;

    private IPlayerStats _stats;

    public void Initialize(IPlayerStats stats, IContextChanger changer)
    {
        int level = 1; // YG2.saves.LevelMagnet

        _stats = stats ?? throw new ArgumentNullException(nameof(stats));

        _magnet.ZoneInitialize(level, _stats);
        _magnet.SetChanger(changer);
    }

    public void SetInputController(IInputController controller)
    {
        _magnet.SetInputController(controller);
    }
}
