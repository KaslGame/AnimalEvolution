using ItemScripts;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopInitializer : MonoBehaviour
{
    [SerializeField] private Shop _view;
    [SerializeField] private UpgradeData[] _upgrades;
    [SerializeField] private PaidMap[] _maps;

    private List<IShopItem> _upgradeItems = new List<IShopItem>();
    private List<IShopItem> _mapItems = new List<IShopItem>();

    public void Initalize(MapStorage storage, ICoinReducer reducer)
    {
        foreach (var upgrade in _upgrades)
            _upgradeItems.Add(new UpgradeItem(upgrade, reducer));

        foreach (var map in _maps)
            _mapItems.Add(new MapItem(map, storage, reducer));

        var upgrades = new Viewer<IShopItem>(_upgradeItems);
        var maps = new Viewer<IShopItem>(_mapItems);

        _view.Initalize(upgrades, maps);
    }
}
