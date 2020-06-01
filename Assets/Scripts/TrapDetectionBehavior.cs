using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDetectionBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if(gameObject.tag == col.tag)
        {
            return;
        }

        GameObject tempGameObject = col.gameObject;
        Destroy(tempGameObject);
    }
}
