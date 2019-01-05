using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeOnStart : MonoBehaviour
{
	[SerializeField] 
	private float desiredScale = 5.0f;

	[SerializeField]
	private float growFactor= 0.1f;

    void Start()
    {
        StartCoroutine(Scale());
    }
 
    IEnumerator Scale()
    {
		while(desiredScale > transform.localScale.x)
        {
			transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
			yield return null;
        }


    }
}
