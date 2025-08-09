using UnityEngine;

namespace FoodScripts
{
    public interface IFood
    {
        void ActiveOutline();
        void DeactivateOutline();
        void SetActive(bool active);
        Vector3 GetPosition();
        int MinLevel { get; }
        bool IsEaten { get; }
    }
}