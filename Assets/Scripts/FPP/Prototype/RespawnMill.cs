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

	}

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name == "Player")
            collider.gameObject.GetComponentInParent<Player>().takeDamage(int.MaxValue);
    }
}
