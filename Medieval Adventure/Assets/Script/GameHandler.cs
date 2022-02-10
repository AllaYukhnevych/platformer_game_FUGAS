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
        Debug.Log(InName);
    }

    public void NextMenu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}