using UnityEngine;
using System.Collections;

public class LoadLevels : MonoBehaviour {

	public void LoadNewScene(int sceneNum){

		Application.LoadLevel(sceneNum);
	}
}
