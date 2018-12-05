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
		if (shouldShoot)
		{
			if (other.CompareTag("rockSmall"))
			{
				other.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * power / 100.0f * force + gameObject.transform.up* power / 100.0f * force, ForceMode.Impulse);

			}
			else if (other.CompareTag("Player"))
			{
				other.GetComponent<PlayerCatapult>().Catapult();
				other.GetComponent<Rigidbody>().AddForce( Vector3.right* power / 100.0f * force + Vector3.up* power / 100.0f * force, ForceMode.Impulse);
			}
			shouldShoot = false;
		}
	}
	
	public void shoot(float _power) {
		shouldShoot = true;
		power = _power;
	}
}
