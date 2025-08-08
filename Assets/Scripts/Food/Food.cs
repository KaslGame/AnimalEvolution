using PlayerScripts;
using UnityEngine;

namespace Food
{
    public class Food : MonoBehaviour
    {
        [SerializeField] private int _minLevel;
        [SerializeField] private float _score;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out IPickUper pickUper))
                TryCollect(pickUper);
        }

        private void TryCollect(IPickUper pickUper)
        {
            if (pickUper.Level >= _minLevel)
            {
                pickUper.PickUp(_score);
                gameObject.SetActive(false);
            }
        }
    }
}