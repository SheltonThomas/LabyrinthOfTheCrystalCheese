using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAnimatorBehavior : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("Triggered");
    }
}
