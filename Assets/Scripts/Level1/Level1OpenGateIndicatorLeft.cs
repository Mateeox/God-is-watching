using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1OpenGateIndicatorLeft : MonoBehaviour {

    private string bulletTagName = "Bullet";
    public GameObject gateObject;
    private Level1OpenGate gate;
    // Use this for initialization
    void Start()
    {
        gate = gateObject.GetComponent<Level1OpenGate>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnCollisionEnter(Collision collider)
    {

        if(collider.gameObject.tag == bulletTagName)
        {
            gate.OnLeftChainDestroy();
        }
    }
}
