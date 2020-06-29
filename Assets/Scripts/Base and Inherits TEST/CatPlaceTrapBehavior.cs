using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPlaceTrapBehavior : MonoBehaviour
{
    private SpawnTrapBaseBehavior trapSpawnBehavior;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("pTrapTwo"))
        {
            trapSpawnBehavior.spawnTrap();
        }
    }
}
