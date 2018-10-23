﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillBehaviorScript : MonoBehaviour {

    public GameObject collisionZone;
    private static float currentSpeed = 150;
    private readonly float zeroSpeed = 0;
    public float speed = 150;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward * Time.deltaTime * currentSpeed);
    }

    public static void SetSpeed(float newSpeed)
    {
        currentSpeed = newSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MillStone")
        {
            currentSpeed = zeroSpeed;
        }
        if (collision.gameObject.name == "Player")
        {
            Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), GameObject.Find("Player").GetComponent<Collider>());
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "MillStone")
        {
            currentSpeed = speed;
        }
    }
}