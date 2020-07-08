using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseAnimationBehavior : MonoBehaviour
{
    private float currentSpeed;
    private IControlable moevemntBehavior;
    private NavMeshAgent agent;
    private Animator animator;

    private void Start()
    {
        moevemntBehavior = GetComponent<MouseMovementBehavior>();
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
        animator.SetFloat("Speed", (currentSpeed / moevemntBehavior.Speed));
    }
}
