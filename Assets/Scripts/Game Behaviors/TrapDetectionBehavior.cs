using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDetectionBehavior : MonoBehaviour
{
    private IControlable agentController;

    public string Owner { get; set; }

    private void OnTriggerEnter(Collider col)
    {
        agentController = col.gameObject.GetComponent<IControlable>();
        // If the trap I triggered is not the owner, Then...
        if (col.name != Owner) 
        {
            agentController.Speed = 1;
            
            Destroy(gameObject);
        }
    }
}

// Notes: if(col.name != Owner) <-- Player