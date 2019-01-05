using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOpener : MonoBehaviour
{
	[SerializeField]
	private GameObject objectToCheck;

	[SerializeField]
	private GameObject teleport;

    void Update()
    {
		if(objectToCheck == null){
			teleport.SetActive(true);
		}
    }
}
