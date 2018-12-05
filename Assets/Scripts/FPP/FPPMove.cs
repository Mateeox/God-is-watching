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
    public float dodgeSpeed = 30.0f;
    public float dodgeMaxTime = 0.2f;
    public float dodgeMaxCooldown = 2.0f;
    private CharacterController characterController;
    private Vector3 moveDirections;
    public float dodgeTime;
    public float dodgeCooldown;

    // Use this for initialization
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        forwardSpeed = 9.0f;
        sideSpeed = 6.0f;
        jumpSpeed = 9.0f;
        rotationSpeed = 120.0f;
        gravity = 20.0f;
        moveDirections = new Vector3(0, 0, 0);
        dodgeTime = dodgeMaxTime;
        dodgeCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameVariables.GameMode == GameVariables.GameModes.Hero)
        {
            //Player rotation
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotationSpeed);
            if(dodgeCooldown > 0)
            {
                dodgeCooldown -= Time.deltaTime;
            }
			moveDirections = transform.up * moveDirections.y + transform.forward * forwardSpeed * Input.GetAxis("Vertical")
                    + transform.right * sideSpeed * Input.GetAxis("Horizontal");
            
            if (characterController.isGrounded)
            {
                
                if (Input.GetButton("Dodge") && dodgeCooldown <=0 && dodgeTime > 0)
                {
                    dodgeTime -= Time.deltaTime;
                    moveDirections += transform.right * dodgeSpeed * Input.GetAxis("Horizontal");
                }else if ((Input.GetButtonUp("Dodge") && dodgeCooldown < 0) || dodgeTime <= 0)
                {
                    dodgeTime = dodgeMaxTime;
                    dodgeCooldown = dodgeMaxCooldown;
                }
               

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