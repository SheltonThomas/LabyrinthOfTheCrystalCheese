using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PursueBehavior : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;

    public bool speedCheck = false;
    float prevSpeed;
    float currentSpeed;
    float speedTimer = 5f;

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
        currentSpeed = agent.speed;
        agent.SetDestination(target.position);

        if (prevSpeed != currentSpeed)
        {
            speedCheck = true;
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
