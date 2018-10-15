using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPPMove : MonoBehaviour {
    public float forwardSpeed;
    public float backwardSpeed;
    public float sideSpeed;
    public float maxForwardSpeed;
    public float maxBackwardSpeed;
    public float maxSideSpeed;
    public float rotationSpeed;
    public float jumpForce;
    private Rigidbody rigidbody;
    public bool inAir;

	// Use this for initialization
	void Start () {
        inAir = false;
        maxForwardSpeed = 6.0f;
        maxBackwardSpeed = 4.0f;
        maxSideSpeed = 5.0f;
        forwardSpeed = 40.0f;
        backwardSpeed = 20.0f;
        sideSpeed = 30.0f;
        rotationSpeed = 120.0f;
        jumpForce = 300.0f;
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if(GameVariables.GameMode == GameVariables.GameModes.Hero)
        {
            //Moving
            if (Input.GetAxis("Vertical") > 0 && !inAir && transform.InverseTransformDirection(rigidbody.velocity).z < maxForwardSpeed)
            {
                rigidbody.AddRelativeForce(0, 0, forwardSpeed);
            }
            else if(Input.GetAxis("Vertical") < 0 && !inAir &&  transform.InverseTransformDirection(rigidbody.velocity).z > -maxBackwardSpeed)
            { 
                rigidbody.AddRelativeForce(0, 0, -backwardSpeed);
            }else if(Input.GetAxis("Vertical") == 0)
            {
                Vector3 localVelocity = transform.InverseTransformDirection(rigidbody.velocity);
                rigidbody.velocity = transform.TransformDirection(localVelocity.x, localVelocity.y, 0);
            }

            if (Input.GetAxis("Horizontal") > 0 && !inAir && transform.InverseTransformDirection(rigidbody.velocity).x < maxSideSpeed)
            {
                rigidbody.AddRelativeForce(sideSpeed, 0, 0);
            }
            else if(Input.GetAxis("Horizontal") < 0 && !inAir && transform.InverseTransformDirection(rigidbody.velocity).x > -maxSideSpeed)
            {
                rigidbody.AddRelativeForce(-sideSpeed, 0, 0);
            }else if(Input.GetAxis("Horizontal") == 0)
            {
                Vector3 localVelocity = transform.InverseTransformDirection(rigidbody.velocity);
                rigidbody.velocity = transform.TransformDirection(0, localVelocity.y, localVelocity.z);
            }

            //Jumping
            if (Input.GetButtonDown("Jump") && !inAir)
            {
                rigidbody.AddRelativeForce(new Vector3(0, jumpForce, 0));
            }

            //Player rotation
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotationSpeed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        inAir = false;
    }

    void OnTriggerExit(Collider other)
    {
        inAir = true;
    }
}
