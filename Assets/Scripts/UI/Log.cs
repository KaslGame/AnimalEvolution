using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Log : MonoBehaviour
{
    private const float UnVisible = 0f;
    private const float Visible = 1f;

    [SerializeField] private CanvasGroup _group;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private float _duration = .5f;


    private bool _isShow;

    public void Show(string text)
    {
        if (_isShow)
            return;

        _isShow = true;
        _group.blocksRaycasts = true;
        _description.text = text;

        _group.DOFade(Visible, _duration).OnComplete(Hide);
    }

    private void Hide()
    {
        _isShow = false;

        _group.blocksRaycasts = false;
        _group.DOFade(UnVisible, _duration);
    }
}
