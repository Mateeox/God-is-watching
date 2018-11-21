using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour {

    public GameObject usedCamera;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.LookAt(usedCamera.transform);
        this.transform.Rotate(Vector3.up - new Vector3(0, 180, 0));
    }
}
