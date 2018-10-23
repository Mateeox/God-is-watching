using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillColiderZoneScript : MonoBehaviour {

    private bool slowDown = false;
    private Collider slowZone;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(slowDown && !slowZone)
        {
            MillBehaviorScript.SetSpeed(150);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "rockBig")
        {
            MillBehaviorScript.SetSpeed(0);
        }
        if(other.gameObject.tag == "SlowZone")
        {
            slowZone = other;
            slowDown = true;
            MillBehaviorScript.SlowDown(4);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "rockBig")
        {
            MillBehaviorScript.SetSpeed(150);
        }
        if(other.gameObject.tag == "SlowZone")
        {
            MillBehaviorScript.SetSpeed(150);
        }
    }
}
