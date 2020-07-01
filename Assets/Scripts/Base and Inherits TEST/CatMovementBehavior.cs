using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovementBehavior : MonoBehaviour, IControlable
{
    public Rigidbody rb { get; set; }
    public Vector3 moveDirection { get; set; }
    public Transform target { get; set; }
    public float speed { get; set; }

    public bool speedCheck { get; set; }
    public float prevSpeed { get; set; }
    public float currentSpeed { get; set; }
    public float speedTimer { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        prevSpeed = speed;
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetButton("HorizontalTwo") && !Input.GetButton("VerticalTwo"))
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation |
                            RigidbodyConstraints.FreezePositionX |
                            RigidbodyConstraints.FreezePositionY;
            return;
        }
        rb.constraints = RigidbodyConstraints.None;

        // Gets Facing Direction
        float moveVertical = Input.GetAxis("VerticalTwo");
        float moveHorizontal = Input.GetAxis("HorizontalTwo");
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