using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPPCameraRotate : MonoBehaviour {

    public float rotationSpeed;
    public float maxRotateAngle;
    public float minRotateAngle;

    // Use this for initialization
    void Start () {
        rotationSpeed = 100.0f;
        maxRotateAngle = 320.0f;
        minRotateAngle = 45.0f;
    }
	
	// Update is called once per frame
	void Update () {
        //Move camera up nad down
        if (GameVariables.GameMode == GameVariables.GameModes.Herose)
        {
            if (!((Input.GetAxis("Mouse Y") > 0 &&
            transform.rotation.eulerAngles.x < maxRotateAngle && transform.rotation.eulerAngles.x > 180) ||
            (Input.GetAxis("Mouse Y") < 0 &&
            transform.rotation.eulerAngles.x > minRotateAngle && transform.rotation.eulerAngles.x < 180)))
            {
                transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0) * Time.deltaTime * rotationSpeed);
            }
        }
    }
}
