using Bootstraps;
using System.Collections;
using UnityEngine;

public class LoaderLevel : MonoBehaviour
{
    [SerializeField] private GameObject _background;
    [SerializeField] private Bootstrap _bootstrap;

    private void Awake()
    {
        StartCoroutine(LoadGame());
    }

    private IEnumerator LoadGame()
    {
        _background.SetActive(true);

        yield return _bootstrap.Load();

        _background.SetActive(false);
    }
}