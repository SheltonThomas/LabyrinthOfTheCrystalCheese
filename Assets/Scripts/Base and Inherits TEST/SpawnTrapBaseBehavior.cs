using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrapBaseBehavior : MonoBehaviour
{
    public GameObject objectToSpawn;
    private TrapDetectionBehavior trapBehavior;

    // Update is called once per frame
    void Update()
    {
        spawnTrap();
    }

    public void spawnTrap()
    {
        // Spawn an instance of the objectToSpawn
        GameObject spawnedInstance = Instantiate(objectToSpawn, transform.position, transform.rotation);
        spawnedInstance.GetComponent<TrapDetectionBehavior>().Owner = transform.parent.gameObject.name;
    }
}
