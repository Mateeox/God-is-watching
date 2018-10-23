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

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name == "Player")
        {
            heroCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            collider.gameObject.transform.position = new Vector3(140.0f, 2.13f, -0.83f);
            collider.gameObject.transform.rotation = new Quaternion(0, 0.7f, 0, 1.0f);
        }
    }
}
