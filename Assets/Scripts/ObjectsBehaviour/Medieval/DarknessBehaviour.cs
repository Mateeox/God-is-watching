using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarknessBehaviour : MonoBehaviour {
	
	public Image darkPlane;
	public VerticalPressurePlate pressurePlate;
	public DarknessGateBehaviour gate;
	private bool isOpened = false;
	
	void Update () {
		if (!isOpened && pressurePlate.isActivated) {
			isOpened = true;
			gate.Open();
			darkPlane.fillCenter = false;
		}
	}
	
	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			darkPlane.fillCenter = true;
		}
	}
}
