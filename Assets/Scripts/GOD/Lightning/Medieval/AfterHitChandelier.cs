using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterHitChandelier : LightningHitable {

	public override void afterHit() {
		GameObject chandelier = this.transform.parent.gameObject;
		foreach (Transform child in chandelier.transform) {
			if (child.GetComponent<Rigidbody>() != null) {
				child.GetComponent<Rigidbody>().isKinematic = false;
			}
			foreach (Transform childOfChild in child.transform) {
				if (childOfChild.GetComponent<Rigidbody>() != null) {
					childOfChild.GetComponent<Rigidbody>().isKinematic = false;
				}
			}
		}
	}
}
