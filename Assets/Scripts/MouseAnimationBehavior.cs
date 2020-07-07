using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseAnimationBehavior : MonoBehaviour
{
    private float currentSpeed;
    private MouseMovementBehavior mouseBehavior;
    private NavMeshAgent agent;
    private Animator mouseAnimator;

    private void Start()
    {
        mouseBehavior = GetComponent<MouseMovementBehavior>();
        agent = GetComponent<NavMeshAgent>();
        mouseAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("MouseTrap"))
        {
            mouseAnimator.SetTrigger("Place Trap");
        }
        currentSpeed = (agent.velocity.magnitude);
        mouseAnimator.SetFloat("Speed", (currentSpeed / mouseBehavior.Speed));
    }
}
