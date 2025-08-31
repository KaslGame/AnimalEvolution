using ItemScripts;
using System;
using UnityEngine;

public class UpgradeItem : IShopItem
{
    private const string Error = "Ошибка.";
    private const string InsufficientFunds = "Недостаточно средств.";
    private const string Successfully = "Успешно";

    private readonly UpgradeData _data;
    private readonly ICoinReducer _reducer;

    public UpgradeItem(UpgradeData data, ICoinReducer reducer)
    {
        _data = data ?? throw new ArgumentNullException(nameof(data));
        _reducer = reducer ?? throw new ArgumentNullException(nameof(reducer));
    }

    public Sprite Icon => _data.Icon;

    public bool IsPurchased => _data.CurrentLevel >= _data.Price.Length;
    public int Price => _data.GetPrice();

    public void Buy(Action<string> callback)
    {
        if (_reducer.CoinCount < Price)
        {
            callback?.Invoke(InsufficientFunds);
            return;
        }

        _reducer.Reduce(Price);
        
        if (_data.TryApply() == false)
            callback?.Invoke(Error);
        else
            callback?.Invoke(Successfully);
    }
}
