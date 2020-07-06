﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PursueBehavior : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;

    private bool speedCheck = false;
    float prevSpeed;
    float currentSpeed;
    float speedTimer = 5f;
    int rageCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        prevSpeed = agent.speed;
        currentSpeed = agent.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameVariables.Paused || GameVariables.GameOver)
        {
            agent.SetDestination(gameObject.transform.position);
            return;
        }

        currentSpeed = agent.speed;
        agent.SetDestination(target.position);

        if (prevSpeed < currentSpeed)
        {
            speedCheck = true;
            speedTimer -= Time.deltaTime;
        }
        else if(rageCounter == 10)
        {
            // If cat hits a certain amount of traps, Gain a temporary burst of speed
            currentSpeed = 7.5f;

            speedCheck = true;
            speedTimer = 5f;
            speedTimer -= Time.deltaTime;
        }
        else
        {
            // Acts like Diminishing Returns 
            speedTimer += Time.deltaTime;
            if (speedTimer > 3f)
            {
                speedTimer = 3f;
            }
        }

        if (currentSpeed < prevSpeed && speedCheck == true)
        {
            if(speedTimer < 0f)
            {
                ResetSpeed();  
            }
            rageCounter++;
            speedCheck = false;
        }
        else if(rageCounter == 10 && speedCheck == true)
        {
            if(speedTimer < 0f)
            {
                ResetSpeed();
            }
            rageCounter = 0;
            speedCheck = false;
        }
    }

    public void SetSpeed(float tempSpeed)
    {
        agent.speed = tempSpeed;
    }

    void ResetSpeed()
    {
        currentSpeed = prevSpeed;
        agent.speed = currentSpeed;
    }
}
