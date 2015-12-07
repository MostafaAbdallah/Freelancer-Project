using UnityEngine;
using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {

	public void EndAPP(){
		//Debug.Log("EXIIIIIT");
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#elif UNITY_WEBPLAYER
		Application.OpenURL(webplayerQuitURL);
		#else
		Application.Quit();
		#endif
	}
}
