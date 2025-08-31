using UnityEngine;

public abstract class UpgradeData : ScriptableObject
{
    public Sprite Icon;
    public int[] Price;

    public abstract int CurrentLevel { get; }

    public abstract bool TryApply();

    public int GetPrice()
    {
        if (Price.Length == 1)
            return Price[0];

        return Price[CurrentLevel];
    }
}
