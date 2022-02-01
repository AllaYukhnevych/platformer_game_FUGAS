using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DieSpace : MonoBehaviour
{
    public GameObject respawn;
    public GameObject pauseMenuUI;
    void Start()
    {
        if (PlayerPrefs.GetInt("PositionPlayer") == 1)
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat("xPosition"), PlayerPrefs.GetFloat("yPosition"));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
                PlayerPrefs.SetInt("PositionPlayer", 1);
                PlayerPrefs.SetFloat("xPosition", transform.position.x);
                PlayerPrefs.SetFloat("yPosition", transform.position.y);
            collision.transform.position = respawn.transform.position;
            Life.health -= 1;
        }
        
        if (Life.health==0)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
    } 
}
