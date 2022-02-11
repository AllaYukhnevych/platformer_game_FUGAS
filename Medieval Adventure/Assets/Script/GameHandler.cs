using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public static string InName;
    public InputField nameInput;
     public void AddPlayer()
    {
        InName = nameInput.text;
    }

    public void NextMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
    public void Exit()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
}