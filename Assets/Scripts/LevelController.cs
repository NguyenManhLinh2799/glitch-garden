using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject endGameScreen;
    [SerializeField] GameObject winText;
    [SerializeField] int numberOfAttackers = 0;

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        var gameTimer = FindObjectOfType<GameTimer>();

        if (gameTimer.IsTimerEnded() && numberOfAttackers <= 0)
        {
            StopAllSunProducers();
            endGameScreen.SetActive(true);
            winText.SetActive(true);
            PlayWinSound();
        }
    }

    private void PlayWinSound()
    {
        var audioSource = winText.GetComponent<AudioSource>();
        if (audioSource)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }

    private void StopAllSunProducers()
    {
        var producers = FindObjectsOfType<SunProducer>();
        foreach (var producer in producers)
        {
            producer.StopProducing();
        }
    }
}
