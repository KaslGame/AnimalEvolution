using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloaderScene : MonoBehaviour
{
    private void Update()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
