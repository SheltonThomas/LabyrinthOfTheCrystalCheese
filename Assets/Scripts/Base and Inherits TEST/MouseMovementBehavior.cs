using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseMovementBehavior : MonoBehaviour, IControlable
{
    public float Speed { get; set; }
    [HideInInspector]
    public NavMeshAgent Agent { get; set; }
    public float SavedSpeed { get; set; }
    public bool Trapped { get; set; }
    public float SlowDuration { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Cancel") && !GameVariables.Paused)
        //{
        //    GameVariables.Paused = true;
        //    SaveCurrentSpeed();
        //}

        //else if (Input.GetButtonDown("Cancel") && GameVariables.Paused)
        //{
        //    GameVariables.Paused = false;
        //    SetCurrentSpeed();
        //}

        //if ((Input.GetButtonUp("Vertical") && Input.GetButtonUp("Horizontal")) || GameVariables.Paused)
        //{
        //    Agent.SetDestination(transform.position);
        //    return;
        //}

        //if(GameVariables.GameOver)
        //{
        //    Agent.SetDestination(transform.position);
        //    return;
        //}

        float verticalMovement = Input.GetAxis("VerticalTwo");
        float horizontalMovement = Input.GetAxis("HorizontalTwo");

        Vector3 movement = new Vector3(horizontalMovement, 0, verticalMovement);

        movement.Normalize();

        movement += transform.position;

        Agent.SetDestination(movement);
    }

    public void SaveCurrentSpeed()
    {
        Speed = SavedSpeed;
    }

    public void SetCurrentSpeed()
    {
        Speed = SavedSpeed;
    }

    public void TrappedSpeed(float slowAmount, float slowDuration)
    {
        if (Trapped)
        {
            float maxSpeed = Speed - slowAmount;
            Agent.speed = maxSpeed;

            SlowDuration += Time.deltaTime;

            if (SlowDuration >= slowDuration)
            {
                SlowDuration = 0;
                Trapped = false;
            }
        }
    }
}
