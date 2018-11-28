using Assets.Scripts.GOD.SlowZone;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZoneCubeBehaviour : MonoBehaviour {

    private GameObject SlowZoneEffect;
    private List<ISlowable> _slowableObjects;
    // Use this for initialization
    void Start () {
        SlowZoneEffect = GameObject.Find("Main Camera").transform.GetChild(0).gameObject;
        _slowableObjects = new List<ISlowable>();
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
            SlowZoneEffect.SetActive(true);
        }
        ISlowable slow = other.gameObject.GetComponent<ISlowable>();
        if (slow != null)
        {
            _slowableObjects.Add(slow);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            SlowZoneEffect.SetActive(false);
        }
        ISlowable slow = other.gameObject.GetComponent<ISlowable>();
        if (slow != null)
        {
            _slowableObjects.Remove(slow);
        }
    }

    private void OnDestroy()
    {
        foreach (ISlowable slow in _slowableObjects)
        {
            slow.SetMaxSpeed();
        }
        SlowZoneEffect.SetActive(false);
    }
}
