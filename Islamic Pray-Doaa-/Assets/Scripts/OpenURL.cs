using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OpenURL : MonoBehaviour {

	public Text t;
	public void OpenURLpage(string URL){
		//t.text = URL;
		Application.OpenURL(URL);

	}
}
