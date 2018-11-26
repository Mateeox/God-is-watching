using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverBottom : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Barrel")
        {
            Debug.Log("In water");
            BarrelBehaviour barrel = collision.gameObject.GetComponent<BarrelBehaviour>();
            barrel.OnGetIntoWater();
            barrel.GoUp();
        }
    }
}
