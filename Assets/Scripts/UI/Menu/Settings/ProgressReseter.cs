using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class ProgressReseter : MonoBehaviour
{
    [SerializeField] private Button _showChoiceButton;
    [SerializeField] private GameObject _choicePanel;
    [SerializeField] private Button _resetButton;
    [SerializeField] private Button _closeButton;

    private void OnEnable()
    {
        _showChoiceButton.onClick.AddListener(ShowChoice);
        _resetButton.onClick.AddListener(ResetProgress);
        _closeButton.onClick.AddListener(CloseChoice);
    }

    private void OnDisable()
    {
        _showChoiceButton.onClick.RemoveListener(ShowChoice);
        _resetButton.onClick.RemoveListener(ResetProgress);
        _closeButton.onClick.RemoveListener(CloseChoice);
    }

    private void ShowChoice()
    {
        SetChoiceActive(true);
    }

    private void ResetProgress()
    {
        YG2.SetDefaultSaves();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void CloseChoice()
    {
        SetChoiceActive(false);
    }

    private void SetChoiceActive(bool active)
    {
        _showChoiceButton.gameObject.SetActive(!active);
        _choicePanel.SetActive(active);
    }
}
