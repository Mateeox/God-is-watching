using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDestroyableScript : MonoBehaviour {
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("chandelierBase")) {
			//this.GetComponent<Rigidbody>().WakeUp();
			this.GetComponent<Rigidbody>().isKinematic = false;
			this.gameObject.transform.localScale = new Vector3(0.85f, 0.85f, 0.85f);
		}
	}		
}
