using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseTrigger : MonoBehaviour
{
    [SerializeField] GameObject endGameScreen;
    [SerializeField] GameObject loseText;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var attacker = collision.GetComponent<Attacker>();
        if (attacker)
        {
            endGameScreen.SetActive(true);
            loseText.SetActive(true);
            PlayLoseSound();

            Time.timeScale = 0f;
        }
    }

    private void PlayLoseSound()
    {
        var audioSource = loseText.GetComponent<AudioSource>();
        if (audioSource)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}
