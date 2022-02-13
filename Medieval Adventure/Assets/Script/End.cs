using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class End : MonoBehaviour
{
    List<InputEntry> entries = new List<InputEntry>();
    string filename = "results.json";
    int maxCount = 10;
    public GameObject pauseMenuUI;

    private void Start()
    {
        entries = FileHandler.ReadListFromJSON<InputEntry>(filename);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AddHighscoreIfPossible(new InputEntry(GameHandler.InName, MoneyText.Coin));
            MoneyText.Coin = 0;
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void SaveHighscore()
    {
        FileHandler.SaveToJSON<InputEntry>(entries, filename);
    }
    public void AddHighscoreIfPossible(InputEntry element)
    {
        for (int i = 0; i < maxCount; i++)
        {
            if (i >= entries.Count || element.points > entries[i].points)
            {
                // add new high score
                entries.Insert(i, element);

                while (entries.Count > maxCount)
                {
                    entries.RemoveAt(maxCount);
                }

                SaveHighscore();

                break;
            }
        }
    }

    public void ButtoResults()
    {
        SceneManager.LoadScene("Results");
    }
    public void ButtonExit()
    {
        Application.Quit();
    }
    public void ButtonMenu()
    {
        SceneManager.LoadScene("Menu");
        PauseManager.numberScen = 4;
    }
}
