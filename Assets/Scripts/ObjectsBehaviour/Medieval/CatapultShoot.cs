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
		}else if(other.CompareTag("Player") && shouldShoot)
        {
            other.GetComponent<Rigidbody>().isKinematic = false;
            other.GetComponent<FPPMove>().enabled = false;
            other.GetComponent<FPPMove>().isShot = true;
            other.GetComponent<Rigidbody>().AddForce(Vector3.right * power / 1400.0f * force + Vector3.up * power / 1400.0f * force, ForceMode.Impulse);
        }
	}
	
	public void shoot(float _power) {
		shouldShoot = true;
		power = _power;
	}
}
