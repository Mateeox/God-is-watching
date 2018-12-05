using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {
	
	public void proceedToNextLevel(float delay) {
		StartCoroutine(proceed(delay));
	}
	
	private IEnumerator proceed(float delay) {
		if (delay > 0.0f) 
		{
			yield return new WaitForSeconds(delay);
		}
		GlobalControl.Set = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
