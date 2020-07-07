using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatAnimationBehavior : MonoBehaviour
{
    private float currentSpeed;
    private IControlable movemntBehavior;
    private NavMeshAgent agent;
    private Animator animator;

    private void Start()
    {
        movemntBehavior = GetComponent<MouseMovementBehavior>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = (agent.velocity.magnitude);
        animator.SetFloat("Speed", (currentSpeed / movemntBehavior.Speed));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Trap")
        {
            animator.SetBool("Trapped", true);
        }
    }
}
