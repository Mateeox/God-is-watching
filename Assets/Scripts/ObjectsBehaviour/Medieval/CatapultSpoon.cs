using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultSpoon : MonoBehaviour {

	private const float powerGrowth = 0.5f;
	private const float rotationPitch = -0.4f * powerGrowth;
	private const float shootRotationPitch = 1.0f;
	private float power;
	private Transform spoon;
	private bool isShot;
	
	public CatapultShoot catapultShoot;
	
	void Start () {
		power = 0.0f;
		spoon = transform.Find("spoonWithStone");
		isShot = false;
	}
	
	void Update() {
		if (isShot) {
			if (spoon.rotation.eulerAngles.x + shootRotationPitch >= 360.0f) 
			{
				spoon.Rotate(360.0f - shootRotationPitch - spoon.rotation.eulerAngles.x, 0.0f, 0.0f);
				isShot = false;
				catapultShoot.shoot(power);
				power = 0.0f;
			}
			else if (spoon.rotation.eulerAngles.x + shootRotationPitch <= 2.0f) 
			{
				isShot = false;
				catapultShoot.shoot(power);
				power = 0.0f;
			}
			else 
			{
				spoon.Rotate(shootRotationPitch, 0.0f, 0.0f);
			}
		}
	}
	
	public bool increasePower() {
		if (power > 99.9999f) 
		{
			return false;
		}
		
		power += powerGrowth;
		if (power > 100.0f) 			
		{
			power = 100.0f;
		}
		spoon.Rotate(rotationPitch, 0.0f, 0.0f);
		return true;
	}
	
	public bool decreasePower() {
		if (power < 0.0001f)
		{
			return false;
		}

		power -= powerGrowth;
		if (power < 0.0f)
		{
			power = 0.0f;
		}
		spoon.Rotate( -rotationPitch, 0.0f, 0.0f);
		return true;
	}
	
	public void shoot() {
		isShot = true;
	}
}
