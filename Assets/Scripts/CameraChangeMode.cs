using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeMode : MonoBehaviour {

    public Camera heroCam;
    public Camera godCam;

	void Start () {
        heroCam.enabled = true;
	}
	
	void Update () {

        //Change camera during changing game mode
        if (Input.GetButtonDown("ChangeMode"))
        {
            heroCam.enabled = !heroCam.enabled;
            godCam.enabled = !godCam.enabled;
            
        }
    }
}
