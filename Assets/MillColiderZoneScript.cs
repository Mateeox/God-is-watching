using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillColiderZoneScript : MonoBehaviour {

    private bool isSlowed = false;
    private bool isBlocked = false;

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
            isBlocked = true;
            MillBehaviorScript.SetSpeed(0);
        }
        if(other.gameObject.tag == "SlowZone")
        {
            isSlowed = true;
            MillBehaviorScript.SlowDown(4);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "rockBig")
        {
            isBlocked = false;
            MillBehaviorScript.SetMaxSpeed();
            if (isSlowed)
            {
                MillBehaviorScript.SlowDown(4);
            }
        }
        if(other.gameObject.tag == "SlowZone")
        {
            isSlowed = false;
            if (!isBlocked)
            {
                MillBehaviorScript.SetMaxSpeed();
            }
            
        }
    }
}
