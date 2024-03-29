﻿using Assets.Scripts.GOD.SlowZone;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZoneCubeBehaviour : MonoBehaviour {
    
    private List<ISlowable> _slowableObjects;
    // Use this for initialization
    void Start () {
        GameObject mainCamera = GameObject.Find("Main Camera");
        for (int i = 0; i < mainCamera.transform.childCount; i++)
        {
            if(mainCamera.transform.GetChild(i).gameObject.name == "SlowZoneEffect")
            {
                _slowableObjects = new List<ISlowable>();
            }
            
        }
       
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void SetActive()
    {
        foreach(ISlowable slow in _slowableObjects)
        {
            slow.SlowDown();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.isInSlowZone = true;
        }
        ISlowable slow = other.gameObject.GetComponent<ISlowable>();
        Debug.Log(other);
        if (slow != null)
        {
            Debug.Log("++"  + other);
            _slowableObjects.Add(slow);
            slow.SlowDown();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.isInSlowZone = false;
        }
        ISlowable slow = other.gameObject.GetComponent<ISlowable>();
        if (slow != null)
        {
            _slowableObjects.Remove(slow);
            slow.SetMaxSpeed();
        }
    }

    private void OnDestroy()
    {
        foreach (ISlowable slow in _slowableObjects)
        {
            slow.SetMaxSpeed();
        }

        Player player = GameObject.Find("Player").GetComponent<Player>();
        player.isInSlowZone = false;

    }
}
