using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
	[SerializeField] 
	private string playerTag;
	[SerializeField] 
	private string sceneName;

	private void OnTriggerEnter(Collider other){
		if(other.CompareTag(playerTag)){
			GetComponent<LoadSceneAsync>().LoadScene(sceneName);
		}
	}
}
