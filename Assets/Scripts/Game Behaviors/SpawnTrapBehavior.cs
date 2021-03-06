﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrapBehavior : MonoBehaviour
{
    public GameObject objectToSpawn;
    private TrapDetectionBehavior trapBehavior;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("pTrapOne"))   // Other one is >> pTrapTwo <<
        {
            spawnTrap();
        }
    }

    void spawnTrap()
    {
        // Spawn an instance of the objectToSpawn
        GameObject spawnedInstance = Instantiate(objectToSpawn, transform.position, transform.rotation);
        spawnedInstance.GetComponent<TrapDetectionBehavior>().Owner = transform.parent.gameObject.name;
    }
}
