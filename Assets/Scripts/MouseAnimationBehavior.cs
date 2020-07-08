using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseAnimationBehavior : MonoBehaviour
{
    public float currentSpeed;
    private IControlable movementBehavior;
    private NavMeshAgent agent;
    private Animator animator;

    private void Start()
    {
        movementBehavior = GetComponent<MouseMovementBehavior>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("MouseTrap"))
        {
            animator.SetTrigger("Place Trap");
        }
        currentSpeed = (agent.velocity.magnitude);
        animator.SetFloat("Speed", (currentSpeed / movementBehavior.Speed));
    }

    private void FixedUpdate()
    {
        currentSpeed = agent.velocity.magnitude / Time.fixedDeltaTime;
    }
}
