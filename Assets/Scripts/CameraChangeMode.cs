using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeMode : MonoBehaviour {

    private Camera camera;

	void Start () {
        camera = GetComponent<Camera>();
	}
	
	void Update () {

        //Change camera during changing game mode
        if (Input.GetButtonDown("ChangeMode"))
        {
            camera.enabled = !camera.enabled;
        }

    }
}
