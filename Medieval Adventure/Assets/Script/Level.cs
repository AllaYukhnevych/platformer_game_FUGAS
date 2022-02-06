using UnityEngine.SceneManagement;
using UnityEngine;

public class Level : MonoBehaviour
{
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
        Time.timeScale = 1f;
    }
    public void ClosePanel()
    {
        SceneManager.LoadScene(0); ;
    }
}
