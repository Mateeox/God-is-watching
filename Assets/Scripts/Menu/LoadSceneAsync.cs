using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneAsync : MonoBehaviour {
	[SerializeField] private GameObject loadingMenu;
	[SerializeField] private Slider sliderProgress;

	public void LoadScene(string name){
		StartCoroutine(LoadAsync(name));
	}
	
	IEnumerator LoadAsync(string scene){
		loadingMenu.SetActive(true);

		AsyncOperation operation = SceneManager.LoadSceneAsync(scene);

		while(!operation.isDone){
			sliderProgress.value = Mathf.Clamp01(operation.progress / 0.9f);

			yield return null;
		}
	}
}
