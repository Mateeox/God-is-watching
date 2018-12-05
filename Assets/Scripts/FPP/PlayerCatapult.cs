using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCatapult : MonoBehaviour {

	private bool isShot;
	private CharacterController characterController;
	private Rigidbody rigidbody;
	private CapsuleCollider capsuleCollider;
	private float distToGround;
	
	void Start () {
		isShot = false;
		characterController = GetComponent<CharacterController>();
		rigidbody = GetComponent<Rigidbody>();
		capsuleCollider = GetComponent<CapsuleCollider>();
		distToGround = capsuleCollider.height + 0.1f;
	}

	
	void Update () {
		if (isShot && Physics.Raycast(transform.position, -Vector3.up, distToGround))
		{
			rigidbody.isKinematic = true;
			characterController.enabled = true;
			isShot = false;
		}
	}
	
	public void Catapult() {
		rigidbody.isKinematic = false;
		characterController.enabled = false;
		isShot = true;
	}
}
