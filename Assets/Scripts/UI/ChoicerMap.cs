using Map;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ItemScripts;

public class ChoicerMap : MonoBehaviour
{
    [SerializeField] private Button _next;
    [SerializeField] private Button _previous;
    [SerializeField] private Button _start;
    [SerializeField] private Image _mapIcon;
    [SerializeField] private Image _lock;

    private MapStorage _mapStorage;

    private List<MapConfig> _allMaps = new List<MapConfig>();
    private MapConfig _currentMap;
    private int _currentMapIndex;
    [SerializeField] private bool _canStart;

    private void OnEnable()
    {
        _next.onClick.AddListener(NextMap);
        _previous.onClick.AddListener(PreviousMap);
        _start.onClick.AddListener(StartGame);
    }

    private void OnDisable()
    {
        _next.onClick.RemoveListener(NextMap);
        _previous.onClick.RemoveListener(PreviousMap);
        _start.onClick.RemoveListener(StartGame);
    }

    public void Initialize(List<MapConfig> mapConfigs, MapStorage mapStorage)
    {
        _allMaps = mapConfigs ?? throw new ArgumentNullException(nameof(mapConfigs));
        _mapStorage = mapStorage ?? throw new ArgumentNullException(nameof(mapStorage));
    }

    private void NextMap()
    {
        _currentMapIndex++;

        if (_currentMapIndex > _allMaps.Count - 1)
            _currentMapIndex = 0;

        UpdateMapView();
    }

    private void PreviousMap()
    {
        _currentMapIndex--;

        if (_currentMapIndex < 0)
            _currentMapIndex = _allMaps.Count - 1;

        UpdateMapView();
    }

    private void StartGame()
    {
        if (_canStart == false)
            return;

        SceneManager.LoadScene(_currentMap.MapName.ToString());
        Time.timeScale = 1f;
    }

    private void UpdateMapView()
    {
        _currentMap = _allMaps[_currentMapIndex];

        if (_currentMap.PaidMap == true)
        {
            if (_mapStorage.IsMapPurchased(_currentMap.MapName.ToString()))
                _canStart = true;
            else
                _canStart = false;
        }
        
        if (_mapStorage.GetLevelMap() >= _currentMap.Level)
            _canStart = true;
        else
            _canStart = false;


        if (_canStart == true)
            _lock.gameObject.SetActive(false);
        else
            _lock.gameObject.SetActive(true);

        _mapIcon.sprite = _currentMap.Icon;
    }
}
