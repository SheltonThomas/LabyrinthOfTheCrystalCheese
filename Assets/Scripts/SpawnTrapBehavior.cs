using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrapBehavior : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject TempSpawnInstance;

    bool canPlaceTrap = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            spawnTrap();
            canPlaceTrap = false;
        }
    }

    void spawnTrap()
    {
        // Spawn an instance of the objectToSpawn
        GameObject spawnedInstance = Instantiate(objectToSpawn, transform.position, transform.rotation);
        TempSpawnInstance = spawnedInstance;
        TempSpawnInstance.tag = "Mouse";
    }
}
