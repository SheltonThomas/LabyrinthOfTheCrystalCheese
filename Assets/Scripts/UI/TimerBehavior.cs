using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBehavior : MonoBehaviour
{
    //Text that is modified to show time remaining.
    [SerializeField]
    private Text timerText;
    
    //Sets how much time the game starts with.
    [HideInInspector]
    public float startTime;

    //Keeps track of time remaining.
    private float timeRemaining;

    void Start()
    {
        startTime = GameVariables.GameLimit;
        //Sets time.
        timeRemaining = startTime;
    }

    void Update()
    {
        //Updates the timer on the screen.
        DrawTimer();
        //Updates time remaining.
        if(!GameVariables.Paused)
        {
            UpdateTimer();
            if(timeRemaining <= 0)
            {
                timeRemaining = 0;
                //Add GameOver Screen
            }
        }
    }

    public void UpdateTimer()
    {
        if (!GameVariables.Paused)
        {
            timeRemaining -= Time.deltaTime;
        }
    }

    public void DrawTimer()
    {
        if(timeRemaining < 10)
        {
            if(Math.Round(timeRemaining, 1) % 1 != 0)
            {
                timerText.text = (Math.Round(timeRemaining, 1)).ToString();
            }
            else
            {
                timerText.text = Math.Round(timeRemaining, 1) + ".0";
            }
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
