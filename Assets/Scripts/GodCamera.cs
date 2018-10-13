using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodCamera : MonoBehaviour {
    
	void Start () {
		
	}
	
	void Update () {
        if (Input.GetButtonDown("ChangeMode"))
        {
            transform.position = new Vector3(GameObject.Find("Player").transform.position.x,
                    transform.position.y, transform.position.z);
        }
	}
}
