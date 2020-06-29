using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovementBehavior : MonoBehaviour
{
    private MovementBaseBehavior movementBehavior;

    // Start is called before the first frame update
    void Start()
    {
        movementBehavior.rb = this.GetComponent<Rigidbody>();
        movementBehavior.prevSpeed = movementBehavior.speed;
        movementBehavior.currentSpeed = movementBehavior.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical"))
        {
            movementBehavior.rb.constraints = RigidbodyConstraints.FreezeRotation |
                            RigidbodyConstraints.FreezePositionX |
                            RigidbodyConstraints.FreezePositionY;
            return;
        }
        movementBehavior.rb.constraints = RigidbodyConstraints.None;

        // Gets Facing Direction
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        // Facing to move with same direction
        Vector3 newPosition = new Vector3(moveHorizontal, 0.0f, moveVertical);
        newPosition.Normalize();
        transform.LookAt(newPosition + transform.position);
        transform.Translate(newPosition * movementBehavior.speed * Time.deltaTime, Space.World);
    }
}
