using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZone : MonoBehaviour {

    public GameObject TimePrefab;
    public float Distance;
    public int Time;

    private Camera _godCam;

	// Use this for initialization
	void Start () {
        _godCam = GameObject.FindGameObjectsWithTag("GodCamera")[0].GetComponent<Camera>();
	}

    private bool _attched = false;
    private bool _set = false;
    private DateTime _timer;
    private GameObject _currZone;

	// Update is called once per frame
	void Update () {
		if(TimePrefab && _godCam)
        {
            if(GameVariables.Ability == GameVariables.Abilities.Time && GameVariables.GameMode == GameVariables.GameModes.God)
            {
                if (!_attched && !_set)
                {
                    _attched = true;
                    _currZone = Instantiate(TimePrefab);
                    _timer = DateTime.Now;
                }
                else if (!_set)
                {
                    Vector3 point = Input.mousePosition;
                    _currZone.transform.position = _godCam.ScreenToWorldPoint(new Vector3(point.x, point.y, Distance));
                }
                
                if(Input.GetButtonDown("Fire1"))
                {
                    _attched = false;
                    _set = true;
                }
            } else
            {
                if (_attched && !_set)
                {
                    _currZone.transform.position = _currZone.transform.position + new Vector3(0, 100.0f, 0);
                    Destroy(_currZone);
                    _attched = false;
                }
            }
        }
        if (_set)
        {
            if (DateTime.Now.Subtract(_timer).Seconds == Time)
            {
                _currZone.transform.position = _currZone.transform.position + new Vector3(0, 100.0f, 0);
                Destroy(_currZone);
                _set = false;
            }
        }
    }
}
