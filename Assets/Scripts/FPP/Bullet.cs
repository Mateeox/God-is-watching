using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Rigidbody rgb;
    private Collider collid;
    // Use this for initialization
    void Start () {
        rgb = gameObject.GetComponent<Rigidbody>();
        collid = gameObject.GetComponent<Collider>();
    }
	
	// Update is called once per frame
	void Update () {
        if (rgb.velocity == Vector3.zero && collid.enabled)
        {
            Destroy(gameObject);
        }else if(rgb.velocity != Vector3.zero && !collid.enabled)
        {
            collid.enabled = true;
        }
	}

    
}
