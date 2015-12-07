using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour {
	public Sprite sprit1;
	public Sprite sprit2;
	public Button b;

	public void Click(){
		/*Debug.Log ("Enter" + b.image.sprite.name);
		b.image.sprite = sprit2;
		StartCoroutine (changeImageOnClick ());*/
		//StartCoroutine (changeImageOnClick ());
	}

	IEnumerator changeImageOnClick(){


		yield return new WaitForSeconds(0.1f);

		b.image.sprite = sprit1;

	}
}
