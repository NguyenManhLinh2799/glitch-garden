using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in SECONDS")]
    [SerializeField] float levelTime = 10f;
    bool timerEnded = false;
    Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        var timePassed = Time.timeSinceLevelLoad;
        
        if (!timerEnded)
        {
            if (timePassed > levelTime)
            {
                timerEnded = true;
                FindObjectOfType<AttackerSpawnerController>().StopSpawning();
            }
            else
            {
                slider.value = timePassed / levelTime;
            }
        }
    }

    public float GetProgress()
    {
        return slider.value;
    }

    public bool IsTimerEnded()
    {
        return timerEnded;
    }
}
