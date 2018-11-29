using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultLever : MonoBehaviour {

	public float leverStartRotationX;
	public float leverEndRotationX;
	public float leverTurningRate;
	
	private Transform lever;
	private CatapultSpoon spoon;
	bool canBePulled;
	bool shouldGoBack;

	void Start() {
		canBePulled = true;
		shouldGoBack = false;
		lever = transform.Find("lever");
		spoon = GetComponent<CatapultSpoon>();
	}
	void Update() {
		if (!canBePulled) 
		{
			if (shouldGoBack) 
			{
				lever.Rotate(leverTurningRate, 0.0f, 0.0f);
				if (lever.rotation.eulerAngles.x >= leverStartRotationX) 
				{
						canBePulled = true;
						shouldGoBack = false;
				}
			}
			else 
			{
				lever.Rotate(-leverTurningRate, 0.0f, 0.0f);
				if (lever.rotation.eulerAngles.x <= leverEndRotationX) 
				{
						shouldGoBack = true;
						spoon.shoot();
				}
			}
		}
	}

	void OnTriggerStay(Collider other) {
		if (other.CompareTag("Player"))
		{
			if (Input.GetButtonDown("PickUpObject") && canBePulled)
			{
				canBePulled = false;
			}
		}
	}
}
