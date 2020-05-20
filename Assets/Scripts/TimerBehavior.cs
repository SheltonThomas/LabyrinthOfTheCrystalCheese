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
    public float startTime = 0;
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
        timerText.text = (Math.Round(timeRemaining, 1)).ToString();
    }
}
