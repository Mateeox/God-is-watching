using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScenesOnTrigger : MonoBehaviour {
	[SerializeField] private string playerTag;
	[SerializeField] private string sceneName;

	[SerializeField] private GameObject loadingMenu;
	[SerializeField] private Slider sliderProgress;

	private void OnTriggerEnter(Collider other){
		if(other.CompareTag(playerTag)){
			StartCoroutine(LoadAsync(sceneName));
		}
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
