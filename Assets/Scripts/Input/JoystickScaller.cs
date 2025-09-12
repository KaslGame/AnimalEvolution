using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class JoystickScaller : MonoBehaviour
{
    [SerializeField] private RectTransform _transform;

    private Vector2 _portraitPosition = new Vector2(0f, 250f);
    private Vector2 _portraitAnchor = new Vector2(0.5f, 0f);
    private Vector2 _landscapePosition = new Vector2(-280f, 280f);
    private Vector2 _landscapeAnchor = new Vector2(1f, 0f);

    private void Awake()
    {
        UpdateJoystickPosition();
    }

    private void OnRectTransformDimensionsChange()
    {
        UpdateJoystickPosition();
    }

    private void UpdateJoystickPosition()
    {
        bool isPortrait = Screen.height >= Screen.width;

        if (isPortrait)
        {
            _transform.anchorMin = _transform.anchorMax = _portraitAnchor;
            _transform.anchoredPosition = _portraitPosition;
        }
        else
        {
            _transform.anchorMax = _transform.anchorMin = _landscapeAnchor;
            _transform.anchoredPosition = _landscapePosition;
        }
    }
}
