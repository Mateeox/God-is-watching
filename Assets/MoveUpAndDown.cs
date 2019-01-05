using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpAndDown : MonoBehaviour
{
	[SerializeField]
	private float minHeight = 0.5f;

	[SerializeField]
	private float maxHeight = 1.5f;

    // Update is called once per frame
    void Update()
    {
		transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, (-minHeight) + maxHeight), transform.localPosition.z);
    }
}
