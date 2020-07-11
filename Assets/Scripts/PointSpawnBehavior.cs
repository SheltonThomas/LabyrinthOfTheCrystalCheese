using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawnBehavior : MonoBehaviour
{
    private GameObject cheeseToSpawn;
    public List<GameObject> CheeseList;
    private GameObject lastSpawnedObject;
    private float cheeseSpawnTimer;
    private float timeToSpawnCheese;
    private bool countingDown;
    public GameObject spawnerLocation;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(spawnerLocation);
        cheeseToSpawn = CheeseList[Random.Range(0, 4)];
        timeToSpawnCheese = Random.Range(3, 15);
        cheeseSpawnTimer = 0;
        countingDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(lastSpawnedObject == null)
        {

        }
        if(lastSpawnedObject == null && !countingDown)
        {
            lastSpawnedObject = Instantiate(cheeseToSpawn, transform.position, transform.rotation);
            cheeseSpawnTimer = timeToSpawnCheese;
            countingDown = true;
        }

        if(countingDown)
        {
            cheeseSpawnTimer -= Time.deltaTime;
        }

        if(cheeseSpawnTimer <= 0)
        {
            cheeseSpawnTimer = 0;
            countingDown = false;
        }
    }
}
