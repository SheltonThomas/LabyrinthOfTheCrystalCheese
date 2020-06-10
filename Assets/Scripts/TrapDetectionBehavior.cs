using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDetectionBehavior : MonoBehaviour
{
    private KeyboardMovementBehavior movementBehavior;
    private PursueBehavior catBehavior;
    [SerializeField]
    public string Owner;

    private void OnTriggerEnter(Collider col)
    {
        movementBehavior = col.GetComponent<KeyboardMovementBehavior>();
        catBehavior = col.GetComponent<PursueBehavior>();

        // If the trap I triggered is not the owner, Then...
        if (catBehavior != null || col.name != Owner) 
        {
            catBehavior.SetSpeed(1f);

            GameObject tempGameObject = gameObject;
            Destroy(tempGameObject);
        }
    }
}

// Notes: if(col.name != Owner) <-- Player