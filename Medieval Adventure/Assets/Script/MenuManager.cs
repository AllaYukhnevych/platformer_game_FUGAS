using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1f;
    }
    public void Settings()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;
    }

    public void Scoreboard()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ButtonExit()
    {
        Application.Quit();
    }
}
