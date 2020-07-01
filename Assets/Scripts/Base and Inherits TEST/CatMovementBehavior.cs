using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatMovementBehavior : MonoBehaviour, IControlable
{
    [HideInInspector]
    public NavMeshAgent Agent { get; set; }
    public float Speed { get; set; }
    public float SavedSpeed { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SaveCurrentSpeed()
    {
        Speed = SavedSpeed;
    }

    public void SetCurrentSpeed()
    {
        Speed = SavedSpeed;
    }
}