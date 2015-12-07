using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChooseShapeManager : MonoBehaviour {
	

	#region Singleton
	static ChooseShapeManager instance;
	public static ChooseShapeManager Instance
	{
		get
		{
			if (!instance)
				instance = new GameObject("ChooseShapeManager").AddComponent<ChooseShapeManager>();
			
			return instance;
		}
	}
	
	#endregion
	
	void Awake()
	{
		//prevent multiple instances of singleton
		if (instance == null)
			instance = this;
		if (this != instance)
			Destroy(this);
	}
	public Sprite[] signImages;
	public AudioClip[] answerSound;
	private AudioSource soundSource;
	private int correctAnswer = -1;
	private Image sign;
	void Start () {
		soundSource = gameObject.GetComponent<AudioSource> ();
		correctAnswer = ChooseTheShape.Instance.initGame ();
	}

	public void CheckANS(int buttonIndex){
		StartCoroutine (CheckAnswer (buttonIndex));
	}

	private IEnumerator CheckAnswer(int buttonIndex){

		Color c;
		if (buttonIndex == correctAnswer) {
			Debug.Log("You Right  brtton = " + buttonIndex + " correctAns = " + correctAnswer);
			sign.sprite = signImages [0];
			c = sign.color;
			sign.color = new Color(c.r, c.g,c.b,255);
			soundSource.clip = answerSound[0];
			soundSource.Play();
		}
		else {
			sign.sprite = signImages [1];
			c = sign.color;
			sign.color = new Color(c.r, c.g,c.b,255);
			soundSource.clip = answerSound[1];
			soundSource.Play();
		}

		yield return new WaitForSeconds (2);
		ChooseTheShape.Instance.ResetGame ();
		correctAnswer = ChooseTheShape.Instance.initGame ();
		ResetSignEffects ();
	}

	public void setSign(Image sign){
		this.sign = sign;
	}

	private void ResetSignEffects(){
		Color c;
		c = sign.color;
		sign.color = new Color(c.r, c.g,c.b,0);
		sign.sprite = null;
		soundSource.Stop ();
	}

}
