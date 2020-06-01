using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovementBehavior : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    public Vector3 moveDirection;
    public Transform target;
    public float speed = 5.0f;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical"))
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
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
}
