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

    public bool speedCheck = false;
    float prevSpeed;
    float currentSpeed;
    float speedTimer;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        prevSpeed = speed;
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if(!GameVariables.GameOver)
                GameVariables.Paused = !(GameVariables.Paused);
        }

        if(GameVariables.Paused || GameVariables.GameOver)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation | 
                            RigidbodyConstraints.FreezePositionX | 
                            RigidbodyConstraints.FreezePositionY;
            return;
        }

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

        if (prevSpeed != currentSpeed)
        {
            speedCheck = true;
            speedTimer -= Time.deltaTime;
        }
        else
        {
            // Acts like Diminishing Returns 
            speedTimer += Time.deltaTime;
            if (speedTimer > 3f)
            {
                speedTimer = 3f;
            }
        }

        if (currentSpeed < prevSpeed && speedCheck == true)
        {
            if (speedTimer < 0f)
            {
                ResetSpeed();
            }
            speedCheck = false;
        }
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
