using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarknessBehaviour : MonoBehaviour {
	
	public VerticalPressurePlate pressurePlate;
	public DarknessGateBehaviour gate;
	public Transform leftExitBlocker;
	public Transform rightExitBlocker;
	private bool isOpened = false;
	
	void Update () {
		if (!isOpened && pressurePlate.isActivated) {
			isOpened = true;
			Vector3 scale = leftExitBlocker.localScale;
			scale.x = 3.63f;
			leftExitBlocker.localScale = scale;
			scale = rightExitBlocker.localScale;
			scale.x = 3.63f;
			rightExitBlocker.localScale = scale;
			gate.Open();
		}
	}
}
