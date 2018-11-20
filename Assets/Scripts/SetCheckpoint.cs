using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCheckpoint : MonoBehaviour {

    private bool _checkpointCaptured = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && !_checkpointCaptured)
        {
            _checkpointCaptured = true;
            other.GetComponentInParent<Player>().SetCheckpoint(this.gameObject);
        }
    }
}
