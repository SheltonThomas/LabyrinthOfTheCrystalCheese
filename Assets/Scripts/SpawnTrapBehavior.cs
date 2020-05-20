using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrapBehavior : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform behaviourTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            spawnTrap();
        }
    }

    void spawnTrap()
    {
        // Spawn an instance of the objectToSpawn
        GameObject spawnedInstance = Instantiate(objectToSpawn, transform.position, transform.rotation);
        // Set the TrapBehaviour's target to the behaviourTarget
        // TrapBehavior trapBehavior = spawnedInstance.GetComponent<TrapBehavior>();
        //if (trapBehavior != null)
        //{
        //    trapBehavior.target = behaviourTarget;
        //}
    }
}
