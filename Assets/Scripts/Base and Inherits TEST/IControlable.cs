using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControlable
{
    Rigidbody rb { get; set; }
    Vector3 moveDirection { get; set; }
    Transform target { get; set; }
    float speed { get; set; }

    bool speedCheck { get; set; }
    float prevSpeed { get; set; }
    float currentSpeed { get; set; }
    float speedTimer { get; set; }

    void SetSpeed(float tempSpeed);

    void ResetSpeed();
}
