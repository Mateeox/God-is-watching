using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPPMove : MonoBehaviour
{

    public float forwardSpeed;
    public float sideSpeed;
    public float jumpSpeed;
    public float rotationSpeed;
    public float gravity;
    private CharacterController characterController;
    private Vector3 moveDirections;

    // Use this for initialization
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        forwardSpeed = 9.0f;
        sideSpeed = 3.0f;
        jumpSpeed = 9.0f;
        rotationSpeed = 120.0f;
        gravity = 20.0f;
        moveDirections = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameVariables.GameMode == GameVariables.GameModes.Hero)
        {
            //Player rotation
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotationSpeed);

            if (characterController.isGrounded)
            {

                moveDirections = transform.forward * forwardSpeed * Input.GetAxis("Vertical")
                     + transform.right * sideSpeed * Input.GetAxis("Horizontal");

                if (Input.GetButtonDown("Jump"))
                {
                    moveDirections.y = jumpSpeed;
                }
            }
            moveDirections.y -= gravity * Time.deltaTime;
            characterController.Move(moveDirections * Time.deltaTime);
        }

    }
}