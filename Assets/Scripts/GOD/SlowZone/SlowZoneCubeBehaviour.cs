using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZoneCubeBehaviour : MonoBehaviour {

    private GameObject SlowZoneEffect;

	// Use this for initialization
	void Start () {
        SlowZoneEffect = GameObject.Find("Main Camera").transform.GetChild(0).gameObject;
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            SlowZoneEffect.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            SlowZoneEffect.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        SlowZoneEffect.SetActive(false);
    }
}
