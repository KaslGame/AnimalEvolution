using UnityEngine;
using YG;

[CreateAssetMenu(fileName = "New boost speed", menuName = "Shop/Upgrades/Create boost speed", order = 53)]
public class SpeedData : UpgradeData
{
    public override int CurrentLevel => YG2.saves.BoostSpeed;

    public override bool TryApply()
    {
        if (CurrentLevel >= Price.Length)
            return false;

        YG2.saves.BoostSpeed++;
        YG2.SaveProgress();

        return true;
    }
}
