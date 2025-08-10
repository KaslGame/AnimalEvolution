using FoodScripts;
using System;
using UnityEngine;

public class TrigerZone : MonoBehaviour
{
    [SerializeField] private BoxCollider _collider;

    public event Action<IMovable> FoodEntered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IMovable food))
            FoodEntered?.Invoke(food);
    }

    public void SetSizeZone(Vector3 size)
    {
        _collider.size = size;
    }
}