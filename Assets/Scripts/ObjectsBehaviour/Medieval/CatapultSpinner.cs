using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultSpinner : MonoBehaviour {
	
	private const float rotationPitch = 5.0f;
	private CatapultSpoon spoon;
	
	void Start () {
		spoon = transform.parent.GetComponent<CatapultSpoon>();
	}

	void OnTriggerStay(Collider other) {
		if (other.CompareTag("Player"))
		{
			if (Input.GetButton("PickUpObject") && spoon.increasePower())
			{
				this.transform.Rotate(0.0f, -rotationPitch, 0.0f);
			}
			/*else if (Input.GetKey(KeyCode.Keypad6) && spoon.decreasePower())
			{
				this.transform.Rotate(0.0f, rotationPitch, 0.0f);
			}*/
		}
    }
}
