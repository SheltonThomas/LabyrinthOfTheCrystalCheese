using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatMovementBehavior : MonoBehaviour, IControlable
{
    public float speed;
    public float Speed { get; set; }
    public NavMeshAgent Agent { get; set; }
    public float SavedSpeed { get; set; }
    public bool Trapped { get; set; }
    public float SlowDuration { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Speed = speed;
        Agent = GetComponent<NavMeshAgent>();
        Agent.speed = Speed;
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetButton("Cancel") && !GameVariables.Paused)
       {
            GameVariables.Paused = true;
            SaveCurrentSpeed();
       }

       if(Input.GetButton("Cancel") && GameVariables.Paused)
       {
            GameVariables.Paused = false;
            SetCurrentSpeed();
       }

       if((Input.GetButtonUp("Vertical") && Input.GetButtonUp("Horizontal")) || GameVariables.Paused)
       {
            Agent.SetDestination(transform.position);
            return;
       }

        float verticalMovement = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");

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
        if(Trapped)
        {
            float maxSpeed = Speed - slowAmount;
            Agent.speed = maxSpeed;

            SlowDuration += Time.deltaTime;

            if(SlowDuration >= slowDuration)
            {
                Agent.speed = Speed;
                SlowDuration = 0;
                Trapped = false;
            }
        }
    }
}