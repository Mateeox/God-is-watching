using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeBossConversion : MonoBehaviour {

	private bool isDone = false;
	
	private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player") {
			other.GetComponent<Player>().beforeBossConversion();
		}
    }
}
