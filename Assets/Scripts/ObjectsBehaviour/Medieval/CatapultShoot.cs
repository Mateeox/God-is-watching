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
			other.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * power / 100.0f * force + gameObject.transform.up* power / 100.0f * force, ForceMode.Impulse);
            //other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX |
            //    RigidbodyConstraints.FreezeRotationY;
            shouldShoot = false;
		}
	}
	
	public void shoot(float _power) {
		shouldShoot = true;
		power = _power;
	}
}
