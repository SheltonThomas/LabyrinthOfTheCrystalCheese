using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatAnimationBehavior : MonoBehaviour
{
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
        animator.SetFloat("Speed", (agent.velocity.magnitude / agent.speed));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Trap")
        {
            animator.SetBool("Trapped", true);
        }
    }
}
