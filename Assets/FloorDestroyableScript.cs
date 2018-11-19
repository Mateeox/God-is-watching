using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDestroyableScript : MonoBehaviour {

    Rigidbody rg;
    private void Awake()
    {
        rg = GetComponent<Rigidbody>();
        rg.Sleep();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
