using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnMill : MonoBehaviour {

    private Camera heroCam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(heroCam)
        {
            heroCam.enabled = true;
            heroCam = null;
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            heroCam = collision.gameObject.GetComponent<Camera>();
            heroCam.enabled = false;
            collision.gameObject.transform.position = new Vector3(35.4f, 2.13f, -0.83f);
            collision.gameObject.transform.rotation = new Quaternion(0, 0.7f, 0, 1.0f);
        }
    }
}
