﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static GameObject pickedObject;
    public static float maxPickUpDistance;

	// Use this for initialization
	void Start () {
        pickedObject = null;
        maxPickUpDistance = 2.25f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}