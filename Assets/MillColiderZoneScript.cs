using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillColiderZoneScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "rockBig")
        {
            MillBehaviorScript.SetSpeed(0);
        }
        if(other.gameObject.tag == "SlowZone")
        {
            MillBehaviorScript.SlowDown(4.0f);
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
