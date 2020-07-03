using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPlaceTrapBehavior : MonoBehaviour
{
    public GameObject objectToSpawn;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("pTrapOne") && GameVariables.CatTraps > 0)
        {
            GameObject trapInstance = Instantiate(objectToSpawn, gameObject.transform);
            trapInstance.GetComponent<TrapDetectionBehavior>().Owner = gameObject.name;
        }
    }
}
