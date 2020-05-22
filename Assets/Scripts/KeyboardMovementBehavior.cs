using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovementBehavior : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;
    public Transform target;
    public float speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        // Find the Direction
        Vector3 moveDirection = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
            moveDirection += new Vector3(0, 0, 1);   // Up
        if (Input.GetKey(KeyCode.A))
            moveDirection += new Vector3(-1, 0, 0);  // Left
        if (Input.GetKey(KeyCode.S))
            moveDirection += new Vector3(0, 0, -1);   // Down
        if (Input.GetKey(KeyCode.D))
            moveDirection += new Vector3(1, 0, 0);   // Right
        moveDirection.Normalize();

        // Set Magnitude
        moveDirection *= speed;

        // Move
        controller.Move(moveDirection * Time.deltaTime);

        //Vector3 relativePos = target.position - transform.position;
        //Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        //transform.rotation = rotation;
    }
}
