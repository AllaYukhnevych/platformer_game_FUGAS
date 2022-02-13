using UnityEngine;

public class Coins : MonoBehaviour
{
    private GameObject player;
    public AudioClip audioClip;
    private AudioSource audioSource;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = player.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MoneyText.Coin += 1;
            audioSource.PlayOneShot(audioClip);
            Destroy(gameObject);
        }
    }
}
