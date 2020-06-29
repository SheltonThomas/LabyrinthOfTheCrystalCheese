using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDetectionBehavior : MonoBehaviour
{
    private KeyboardMovementBehavior movementBehavior;
    [HideInInspector]
    public string Owner { get; set; }

    private void OnTriggerEnter(Collider col)
    {
        movementBehavior = col.GetComponent<KeyboardMovementBehavior>();

        // If the trap I triggered is not the owner, Then...
        if (col.name != Owner) 
        {
            movementBehavior.SetSpeed(1f);

            GameObject tempGameObject = gameObject;
            Destroy(tempGameObject);
        }
    }
}

// Notes: if(col.name != Owner) <-- Player