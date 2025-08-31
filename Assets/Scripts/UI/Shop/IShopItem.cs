using System;
using UnityEngine;

public interface IShopItem
{
    public Sprite Icon { get; }
    public bool IsPurchased { get; }
    public void Buy(Action<string> callback);
}
