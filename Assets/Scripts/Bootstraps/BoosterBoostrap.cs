using BoostersScripts;
using Bootstraps;
using CharacterSystem;
using Input;
using System;
using System.Collections;
using UnityEngine;
using YG;

public class BoosterBoostrap : Bootstrap
{
    [SerializeField] private MagnetBooster _magnet;

    private IPlayerStats _stats;
    private IContextChanger _changer;

    public void Initialize(IPlayerStats stats, IContextChanger changer)
    {
        _stats = stats ?? throw new ArgumentNullException(nameof(stats));
        _changer = changer ?? throw new ArgumentNullException(nameof(changer));
    }

    public override IEnumerator Load()
    {
        int level = YG2.saves.LevelMagnet;

        _magnet.ZoneInitialize(level, _stats);
        _magnet.SetChanger(_changer);

        yield return null;
    }

    public void SetInputController(IInputController controller)
    {
        _magnet.SetInputController(controller);
    }
}
