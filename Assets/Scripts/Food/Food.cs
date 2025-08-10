using PlayerScripts;
using UnityEngine;

namespace FoodScripts
{
    [RequireComponent(typeof(Outline))]
    public class Food : MonoBehaviour, IFood, IEdible
    {
        [SerializeField] private int _minLevel;
        [SerializeField] private float _score;

        private Outline _outline;
        private bool _isEaten;

        public int MinLevel => _minLevel;
        public bool IsEaten => _isEaten;

        private void Awake()
        {
            _outline = GetComponent<Outline>(); 
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out IPickUper pickUper))
                if (pickUper.Level >= _minLevel)
                    Collect(pickUper);
        }

        public void ActiveOutline()
        {
            _outline.enabled = true;
        }

        public void DeactivateOutline()
        {
            _outline.enabled = false;
        }

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }

        public Vector3 GetPosition()
        {
            return gameObject.transform.position;
        }

        public void Collect(IPickUper pickUper)
        {
            pickUper.PickUp(_score);
            gameObject.SetActive(false);
            _isEaten = true;
        }
    }
}