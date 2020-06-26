using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrapBehavior : MonoBehaviour
{
    public GameObject objectToSpawn;
    private TrapDetectionBehavior trapBehavior;

    // Update is called once per frame
    void Update()
    {
        if (GameVariables.Paused || GameVariables.GameOver)
            return;

        if (Input.GetButtonDown("Jump") && GameVariables.MouseTraps != 0)
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
