using System.Collections;
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
    bool rageActive = false;
    public List<GameObject> spawnLocations;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        prevSpeed = agent.speed;
        currentSpeed = agent.speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(transform.position.magnitude - spawnLocations[0].transform.position.magnitude > transform.position.magnitude - spawnLocations[1].transform.position.magnitude)
        {
            collision.gameObject.transform.position = spawnLocations[0].transform.position;
        }
        else
        {
            collision.gameObject.transform.position = spawnLocations[1].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameVariables.Paused || GameVariables.GameOver)
        {
            agent.SetDestination(gameObject.transform.position);
            return;
        }

        currentSpeed = agent.velocity.magnitude;
        agent.SetDestination(target.position);

        if(GameVariables.CatScore < GameVariables.MouseScore)
        {
            currentSpeed += 0.02f;
        }
        else if (GameVariables.CatScore > GameVariables.MouseScore)
        {
            ResetSpeed();
        }

        if (currentSpeed < prevSpeed && speedCheck == false)
        {
            speedCheck = true;
            speedTimer -= Time.deltaTime;
        }
        else if (rageCounter >= 10 && rageActive == false)
        {
            // If cat hits a certain amount of traps, Gain a temporary burst of speed
            SetSpeed(75f);
            rageActive = true;
        }
        else
        {
            // Acts like Diminishing Returns 
            speedTimer += Time.deltaTime;
            if (speedTimer > 3f && rageCounter < 10)
            {
                speedTimer = 3f;
            }
            else if(rageCounter >= 10)
            {
                if (speedTimer > 5f)
                {
                    speedTimer = 5f;
                }
            }
        }

        if (currentSpeed < prevSpeed && speedCheck == true)
        {
            if (rageActive != true)
            {
                if (speedTimer < 0f)
                {
                    ResetSpeed();
                    rageCounter++;
                }
            }
            speedCheck = false;
        }
        else if(rageCounter >= 10)
        {
            if(speedTimer >= 5f)
            {
                ResetSpeed();
                rageCounter = 0;
                rageActive = false;
            }
            speedCheck = false;
        }

        // If for some reason ResetSpeed gets stuck
        if(speedTimer < -1f && currentSpeed < prevSpeed)
        {
            ResetSpeed();
            speedTimer = 3;
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
