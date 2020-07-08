using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrapDetectionBehavior : MonoBehaviour
{
    private NavMeshAgent agentController;

    private Animator animator;

    public string Owner { get; set; }

    private bool delete = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (delete && animator.GetCurrentAnimatorStateInfo(0).IsName("Closing"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        // If the trap I triggered is not the owner, Then...
        if (collision.gameObject.name == "Cat")
        {
            agentController = collision.gameObject.GetComponent<NavMeshAgent>();
            agentController.speed /= 2;

            animator.SetTrigger("Triggered");
            delete = true;
        }
    }
}