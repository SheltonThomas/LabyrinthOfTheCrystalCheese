using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IControlable
{
    NavMeshAgent Agent { get; set; }
    float Speed { get; set; }
    float SavedSpeed { get; set; }

    void SaveCurrentSpeed();

    void SetCurrentSpeed();
}
