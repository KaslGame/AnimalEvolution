using System;
using ItemScripts;
using UnityEngine;

public class MapItem : IShopItem
{
    private const string Error = "Ошибка.";
    private const string InsufficientFunds = "Недостаточно средств.";
    private const string Successfully = "Успешно";

    private readonly PaidMap _map;
    private readonly MapStorage _storage;
    private readonly ICoinReducer _reducer;

    public MapItem(PaidMap map, MapStorage storage, ICoinReducer reducer)
    {
        _map = map ?? throw new ArgumentNullException(nameof(map));
        _storage = storage ?? throw new ArgumentNullException(nameof(storage));
        _reducer = reducer ?? throw new ArgumentNullException(nameof(reducer));
    }

    public Sprite Icon => _map.Icon;

    public bool IsPurchased => _storage.IsMapPurchased(_map.MapName);

    public int Price => _map.Price;

    public void Buy(Action<string> callback)
    {
        if (_reducer.CoinCount < _map.Price)
        {
            callback?.Invoke(InsufficientFunds);
            return;
        }

        _reducer.Reduce(_map.Price);
        _storage.TryBuyMap(_map.MapName);

        if (IsPurchased)
            callback?.Invoke(Successfully);
        else
            callback?.Invoke(Error);
    }
}
