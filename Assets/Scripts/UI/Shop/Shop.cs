using System;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _previosButton;
    [SerializeField] private Button _upgradesButton;
    [SerializeField] private Button _mapsButton;
    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _menuButton;
    [SerializeField] private MenuChanger _changer;

    [SerializeField] private Image _itemIcon;

    [SerializeField] private Log _log;

    private Viewer<IShopItem> _maps;
    private Viewer<IShopItem> _upgrades;
    private Viewer<IShopItem> _currentViewer;

    private IShopItem _currentItem;

    public void Initalize(Viewer<IShopItem> maps, Viewer<IShopItem> upgrades)
    {
        _maps = maps ?? throw new ArgumentNullException(nameof(maps));
        _upgrades = upgrades ?? throw new ArgumentNullException(nameof(upgrades));

        _currentViewer = _upgrades;
        NextItem();
    }

    private void OnEnable()
    {
        _nextButton.onClick.AddListener(NextItem);
        _previosButton.onClick.AddListener(PreviousItem);
        _upgradesButton.onClick.AddListener(SetUpgradeItems);
        _mapsButton.onClick.AddListener(SetMapItems);
        _buyButton.onClick.AddListener(Buy);
        _menuButton.onClick.AddListener(ChangeMenu);
    }

    private void OnDisable()
    {
        _nextButton.onClick.RemoveListener(NextItem);
        _previosButton.onClick.RemoveListener(PreviousItem);
        _upgradesButton.onClick.RemoveListener(SetUpgradeItems);
        _mapsButton.onClick.RemoveListener(SetMapItems);
        _buyButton.onClick.RemoveListener(Buy);
        _menuButton.onClick.RemoveListener(ChangeMenu);
    }

    private void NextItem()
    {
        _currentItem = _currentViewer.GetNextItem();
        UpdateView();
    }

    private void PreviousItem()
    {
        _currentItem = _currentViewer.GetPreviosItem();
        UpdateView();
    }

    private void Buy()
    {
        _currentItem.Buy(_log.Show);
        UpdateView();
    }

    private void ChangeMenu()
    {
        _changer.SetMenu(MenuNames.MainMenu);
    }

    private void SetUpgradeItems()
    {
        _currentViewer = _upgrades;
        NextItem();
    }

    private void SetMapItems()
    {
        _currentViewer = _maps;
        NextItem();
    }

    private void UpdateView()
    {
        _itemIcon.sprite = _currentItem.Icon;
        _buyButton.interactable = !_currentItem.IsPurchased;
    }
}
