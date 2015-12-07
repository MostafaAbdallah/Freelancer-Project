using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadLevelsWithLoadingBar : MonoBehaviour {

	public Slider loadingBar;
	public GameObject loadingImage;

	AsyncOperation Async;

	public void LoadLevelAsync(int Level){

		loadingImage.SetActive (true);
		StartCoroutine (LoadingAsync (Level));
	}

	IEnumerator LoadingAsync(int Level){

		Async = Application.LoadLevelAsync (Level);

		while (!Async.isDone) {
			loadingBar.value = Async.progress;
			yield return null;
		}
	}
}
