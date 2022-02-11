using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public static bool GameIsPause = false;
    public static int numberScen;
   
    public void StartPause()
    {
         if (GameIsPause)
            {
                Restart();
            }
            else
            {
                Pause();
            }
    }
    public void ButtonRestart()
    {
        PlayerPrefs.SetInt("PositionPlayer", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void ButtonMenu()
    {
        SceneManager.LoadScene("Menu");
        PlayerPrefs.SetInt("PositionPlayer", 0);
        numberScen =  SceneManager.GetActiveScene().buildIndex;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    void Restart()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }
}
