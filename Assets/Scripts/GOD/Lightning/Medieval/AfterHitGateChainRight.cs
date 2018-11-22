using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterHitGateChainRight : LightningHitable
{

	public GameObject gateObject;
    private Level1OpenGate gate;


    // Use this for initialization
    void Start()
    {
        gate = gateObject.GetComponent<Level1OpenGate>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void afterHit()
    {
        gate.OnRightChainDestroy();
    }
}
