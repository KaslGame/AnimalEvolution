using FoodScripts;
using System;
using UnityEngine;

public class TrigerZone : MonoBehaviour
{
    [SerializeField] private BoxCollider _collider;

    private Vector3 _standartSize = new Vector3(5f, 2f, 5f);
    private IPlayerStats _stats;

    public event Action<IMovable> FoodEntered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IFood levelFood) && _stats.Level >= levelFood.MinLevel)
        {
            if (other.TryGetComponent(out IMovable movable))
                FoodEntered?.Invoke(movable);
        }
    }

    public void Initialize(int levelMagnet, IPlayerStats stats)
    {
        Vector3 newSize = new(_standartSize.x + levelMagnet, _standartSize.y, _standartSize.z + levelMagnet);

        _stats = stats ?? throw new ArgumentNullException(nameof(stats));
        _collider.size = newSize;
    }
}