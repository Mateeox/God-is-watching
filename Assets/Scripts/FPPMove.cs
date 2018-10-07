using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPPMove : MonoBehaviour {
    public float forwardSpeed;
    public float backwardSpeed;
    public float sideSpeed;
    public float rotationSpeed;

	// Use this for initialization
	void Start () {
        forwardSpeed = 6.0f;
        backwardSpeed = 3.0f;
        sideSpeed = 5.0f;
        rotationSpeed = 120.0f;
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        //Player moving        
        if (Input.GetAxis("Vertical") > 0)
        {
            transform.Translate(0, 0, forwardSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        }else if (Input.GetAxis("Vertical") < 0)
        {
            transform.Translate(0, 0, backwardSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        }
            transform.Translate(sideSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0, 0);
              
        //Player rotation
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotationSpeed);


    }
}
