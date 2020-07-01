using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovementBehavior : MonoBehaviour, IControlable
{
    public Rigidbody rb { get; set; }
    public Vector3 moveDirection { get; set; }
    public Transform target { get; set; }
    public float speed { get; set; }

    public bool speedCheck { get; set; }
    public float prevSpeed { get; set; }
    public float currentSpeed { get; set; }
    public float speedTimer { get; set; }

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        prevSpeed = speed;
        currentSpeed = speed;
    }
    
    void Update()
    {
        if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical"))
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation |
                            RigidbodyConstraints.FreezePositionX |
                            RigidbodyConstraints.FreezePositionY;
            return;
        }
        rb.constraints = RigidbodyConstraints.None;

        // Gets Facing Direction
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        // Facing to move with same direction
        Vector3 newPosition = new Vector3(moveHorizontal, 0.0f, moveVertical);
        newPosition.Normalize();
        transform.LookAt(newPosition + transform.position);
        transform.Translate(newPosition * speed * Time.deltaTime, Space.World);
    }

    public void SetSpeed(float tempSpeed)
    {
        speed = tempSpeed;
    }

    public void ResetSpeed()
    {
        currentSpeed = prevSpeed;
        speed = currentSpeed;
    }
}
