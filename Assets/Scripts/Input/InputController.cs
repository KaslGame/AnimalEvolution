using UnityEngine;

namespace Input
{
    public abstract class InputController : MonoBehaviour, IInputController
    {
        public Vector3 Direction { get; private set; }

        private void Update()
        {
            ReadMove();
        }

        protected void ChangeDirection(Vector2 direction)
        {
            Direction = new Vector3(direction.x, 0, direction.y).normalized;
        }

        protected abstract void ReadMove();
    }
}