using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(PauseManager.numberScen);
        Time.timeScale = 1f;
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
        Time.timeScale = 1f;
    }

    public void Results()
    {
        SceneManager.LoadScene("Results");
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void ButtonExit()
    {
        Application.Quit();
    }
}
