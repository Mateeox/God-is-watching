using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarknessBehaviour : MonoBehaviour {
	
	public VerticalPressurePlate pressurePlate;
	public DarknessGateBehaviour gate;
	private bool isOpened = false;
	
	void Update () {
		if (!isOpened && pressurePlate.isActivated) {
			isOpened = true;
			gate.Open();
		}
	}
}
