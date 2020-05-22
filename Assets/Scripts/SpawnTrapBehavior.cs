using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrapBehavior : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float slowdownSpeed = 2.0f;

    private void OnTriggerEnter(Collider col)
    {
        GameObject tempGameObject = col.gameObject;
        Destroy(tempGameObject);
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
    }


}
