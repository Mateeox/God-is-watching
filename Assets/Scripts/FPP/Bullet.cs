using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.GetComponent<Rigidbody>().velocity == Vector3.zero)
        {
            Destroy(gameObject);
        }
	}

    
}
