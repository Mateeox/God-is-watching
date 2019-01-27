using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDestroyer : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow")) {
			Destroy(other.transform.gameObject);
		}
    }
}
