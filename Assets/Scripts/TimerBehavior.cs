using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBehavior : MonoBehaviour
{
    [SerializeField]
    private Text timerText;
    
    [HideInInspector]
    public float startTime;

    private float timeRemaining;
    public float TimeRemaining { get; }

    void Start()
    {
        timeRemaining = startTime;
    }

    void Update()
    {
        DrawTimer();
        UpdateTimer();
    }

    public void UpdateTimer()
    {
        if (!PauseMenuBehavior.Paused)
        {
            timeRemaining -= Time.deltaTime;
        }
    }

    public void DrawTimer()
    {
        if(timeRemaining <= 10)
        {
            timerText.text = (Math.Round(timeRemaining, 1)).ToString();
        }
        else if (timeRemaining <= 60)
        {
            timerText.text = ((int)timeRemaining).ToString();
        }
        else
        {
            int minutes = (int)(timeRemaining / 60);
            float seconds = timeRemaining - (minutes * 60);
            if(seconds < 10)
            {
                timerText.text = minutes + ":0" + (int)seconds;
            }
            else
            {
                timerText.text = minutes + ":" + (int)seconds;
            }
        }

        if(timeRemaining <= 0)
        {
            timeRemaining = 0;
        }
    }
}
