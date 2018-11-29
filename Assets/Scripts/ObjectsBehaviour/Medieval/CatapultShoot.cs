using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultShoot : MonoBehaviour {

	public bool shouldShoot;
	public float force;
	private float power;
	void Start() {
		shouldShoot = false;
	}
	
	void OnTriggerStay(Collider other) {
		if (other.CompareTag("rockSmall") && shouldShoot)
		{
			other.GetComponent<Rigidbody>().AddForce(power / 100.0f * force, power / 100.0f * force, 0.0f, ForceMode.Impulse);
			shouldShoot = false;
		}
	}
	
	public void shoot(float _power) {
		shouldShoot = true;
		power = _power;
	}
}
