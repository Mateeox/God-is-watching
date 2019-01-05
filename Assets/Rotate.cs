using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
	[SerializeField]
	private Vector3 angles;

	private void Update(){
		transform.Rotate(angles * Time.deltaTime);
	}
}
