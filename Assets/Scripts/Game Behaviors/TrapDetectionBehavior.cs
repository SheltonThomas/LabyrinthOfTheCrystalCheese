using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDetectionBehavior : MonoBehaviour
{
  //  private IControlable agentController;
    private PursueBehavior catBehavior;

    public string Owner { get; set; }

    private void OnTriggerEnter(Collider col)
    {
      //  agentController = col.gameObject.GetComponent<IControlable>();
        catBehavior = col.gameObject.GetComponent<PursueBehavior>();

        // If the trap I triggered is not the owner, Then...
        if (col.name != Owner) 
        {
        //    agentController.Speed = 30;
            catBehavior.SetSpeed(5f);

            GameObject tempGameObject = gameObject;
            Destroy(tempGameObject);
        }
    }
}

// Notes: if(col.name != Owner) <-- Player