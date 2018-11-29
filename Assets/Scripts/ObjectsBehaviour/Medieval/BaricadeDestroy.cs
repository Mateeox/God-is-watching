using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaricadeDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnColliderEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("rockSmall"))
        {
            gameObject.AddComponent<Rigidbody>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("T: " + other.tag);
        if (other.CompareTag("rockSmall"))
        {
            gameObject.GetComponent<Collider>().isTrigger = false;
            gameObject.AddComponent<Rigidbody>();
        }
    }
}
