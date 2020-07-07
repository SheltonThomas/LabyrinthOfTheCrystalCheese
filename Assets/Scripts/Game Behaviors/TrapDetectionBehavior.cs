using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDetectionBehavior : MonoBehaviour
{
    private IControlable agentController;

    private Animator animator;

    public string Owner { get; set; }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider col)
    {
        agentController = col.gameObject.GetComponent<IControlable>();
        // If the trap I triggered is not the owner, Then...
        if (col.name != Owner) 
        {
            agentController.Speed = 1;

            animator.SetTrigger("Triggered");

            if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Triggered"))
            {
                Destroy(gameObject);
            }
        }
    }
}