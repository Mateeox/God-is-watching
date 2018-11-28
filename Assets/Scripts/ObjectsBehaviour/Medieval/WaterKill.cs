using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterKill : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {        

        if (other.gameObject.name == "Player")
        {
            other.gameObject.GetComponentInParent<Player>().takeDamage(int.MaxValue);
        }
    }
}
