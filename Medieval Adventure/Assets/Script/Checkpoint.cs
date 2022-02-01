using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt("PositionPlayer") == 1)
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat("xPosition"), PlayerPrefs.GetFloat("yPosition"));
        }
        else if (PlayerPrefs.GetInt("PositionPlayer") == 0)
        {
            transform.position = new Vector2(-4.83f, -2.57f);
        }
 }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("cheackpoint"))
        {
            PlayerPrefs.SetInt("PositionPlayer", 1);
            PlayerPrefs.SetFloat("xPosition", transform.position.x);
            PlayerPrefs.SetFloat("yPosition", transform.position.y);
        }

    }

    public void Reset()
    {
        PlayerPrefs.SetInt("PositionPlayer", 0);
    }

}
