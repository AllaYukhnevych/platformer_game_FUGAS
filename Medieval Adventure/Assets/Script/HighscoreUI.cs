using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighscoreUI : MonoBehaviour
{
    [SerializeField] GameObject highscoreUIElementPrefab;
    [SerializeField] Transform elementWrapper;

    List<GameObject> uiElements = new List<GameObject>();

    private void OnEnable()
    {
        HighscoreHandler.onHighscoreListChanged += UpdateUI;
    }

    private void OnDisable()
    {
        HighscoreHandler.onHighscoreListChanged -= UpdateUI;
    }
       
    public void ClosePanel()
    {
        SceneManager.LoadScene(0); ;
    }

    private void UpdateUI(List<HighscoreElement> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            HighscoreElement el = list[i];

            if (el != null && el.points > 0)
            {
                if (i >= uiElements.Count)
                {
                    // instantiate new entry
                    var inst = Instantiate(highscoreUIElementPrefab, Vector3.zero, Quaternion.identity);
                    inst.transform.SetParent(elementWrapper, false);
                   
                    uiElements.Add(inst);
                }

                // write or overwrite name & points
                var texts = uiElements[i].GetComponentsInChildren<Text>();
                texts[0].text = el.playerName;
                texts[1].text = el.points.ToString();
            }
        }
    }

}