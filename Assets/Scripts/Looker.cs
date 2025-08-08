using UnityEngine;

public class Looker : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void LateUpdate()
    {
        _transform.LookAt(transform.position + _target.forward);
    }
}
