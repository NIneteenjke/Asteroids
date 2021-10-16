using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float thrustSpeed = 1.0f;

    public float turnSpeed = 1.0f;

    private Rigidbody2D rigidB;

    private bool thrusting;

    private float turnDirection;

    private void Awake()
    {
        rigidB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        thrusting = Input.GetKey(KeyCode.UpArrow);
        if (Input.GetKey(KeyCode.LeftArrow))
            {
                turnDirection = 1.0f;
            } 
            else if ( Input.GetKey(KeyCode.RightArrow))
                {
                turnDirection = -1.0f;
                }
                else
                {
                    turnDirection =0.0f;
                }

    }

    private void FixedUpdate()
    {
        if (thrusting)
        {
            rigidB.AddForce(this.transform.up * this.thrustSpeed);
        }
        if (turnDirection != 0.0f)
        {
            rigidB.AddTorque(turnDirection * this.turnSpeed);
        }
    }
}
