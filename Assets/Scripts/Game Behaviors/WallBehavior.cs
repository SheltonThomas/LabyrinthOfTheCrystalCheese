using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WallBehavior : MonoBehaviour
{
    private MeshRenderer wallRenderer;

    private Collider wallCollider;

    private NavMeshObstacle navMeshObstacle;

    public float timeToActivate;

    private float timeTilActive;

    bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        timeTilActive = timeToActivate;

        wallRenderer = GetComponent<MeshRenderer>();
        wallCollider = GetComponent<Collider>();
        navMeshObstacle = GetComponent<NavMeshObstacle>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
        if(active)
        {
            wallRenderer.enabled = true;
            wallCollider.enabled = true;
            navMeshObstacle.enabled = true;
        }
    }

    void UpdateTimer()
    {
        timeTilActive -= Time.deltaTime;
        if(timeTilActive <= 0)
        {
            active = true;
        }
    }
}
