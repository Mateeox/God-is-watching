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
	public bool manualUpdate (float currentMana, ref bool isTooLittleMana) {
		bool abilityUsed = false;
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
                
                if(Input.GetButtonDown("Fire1") && !_set)
                {
					if(currentMana >= (int)GameVariables.Abilities.Time)
					{
						abilityUsed = true;
						_attched = false;
						_set = true;
					}
					else
					{
						//not enough mana!!!oneoneone
						Debug.Log("Too little mana for slow zone");
						isTooLittleMana = true;
					}
                }
            } else
            {
                if (_attched && !_set)
                {
                    Destroy(_currZone);
                    _attched = false;

                }
            }
        }
        if (_set)
        {
            if (DateTime.Now.Subtract(_timer).Seconds == Time)
            {
                Destroy(_currZone);
                _set = false;
                
                if (!MillColiderZoneScript.isBlocked)
                {
                    MillBehaviorScript.SetMaxSpeed();
                }
            }
        }
		return abilityUsed;
    }
    
}
