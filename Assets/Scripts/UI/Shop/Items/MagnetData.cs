using UnityEngine;
using YG;

[CreateAssetMenu(fileName = "New magnet", menuName = "Shop/Upgrades/Create magnet", order = 53)]
public class MagnetData : UpgradeData
{
    public override int CurrentLevel => YG2.saves.LevelMagnet;

    public override bool TryApply()
    {
        if (CurrentLevel >= Price.Length)
            return false;

        YG2.saves.LevelMagnet++;
        YG2.SaveProgress();

        return true;
    }
}
