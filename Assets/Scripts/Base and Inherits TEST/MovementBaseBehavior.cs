using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBaseBehavior : MonoBehaviour
{
    [SerializeField]
    public Rigidbody rb;
    public Vector3 moveDirection;
    public Transform target;
    public float speed = 5.0f;

    public bool speedCheck = false;
    public float prevSpeed;
    public float currentSpeed;
    public float speedTimer;

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
        if (Input.GetButtonDown("Cancel"))
        {
            GameVariables.Paused = !(GameVariables.Paused);
        }

        if (GameVariables.Paused)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation |
                            RigidbodyConstraints.FreezePositionX |
                            RigidbodyConstraints.FreezePositionY;
            return;
        }
        rb.constraints = RigidbodyConstraints.None;

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
