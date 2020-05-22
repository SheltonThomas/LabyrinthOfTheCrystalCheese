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
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));   // Up & Down & Left & Right
        moveDirection.Normalize();

        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 newPosition = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.LookAt(newPosition + transform.position);
        transform.Translate(newPosition * speed * Time.deltaTime, Space.World);
    }

    void FixedUpdate()
    {
        // Set Magnitude
        MovePlayer(moveDirection);
    }

    void MovePlayer(Vector3 direction)
    {
        rb.MovePosition((Vector3)transform.position + (direction * speed * Time.deltaTime));
    }
}
