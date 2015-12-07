using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

	#region Singleton
	static SoundManager instance;
	public static SoundManager Instance
	{
		get
		{
			if (!instance)
				instance = new GameObject("SoundManager").AddComponent<SoundManager>();
			
			return instance;
		}
	}
	
	#endregion
	

	public GameObject soundClip;
	public List <AudioClip> soundAudio = new List<AudioClip>();
	private AudioSource soundSource;
	public static SoundManager Inst;
	public Button b;
	public Sprite []s;
	bool soundOn ;

	void Awake()
	{
		//prevent multiple instances of singleton
		if (instance == null)
			instance = this;
		if (this != instance)
			Destroy(this);
	}
	// Use this for initialization
	void Start () {
		//soundManager = this;
		Inst = this;
		soundSource = soundClip.GetComponent<AudioSource>();
		soundOn = true;
	}

	public void playSound(string letterName){

		if (soundOn) {
		
			foreach (AudioClip clip in soundAudio) {
				//Debug.Log("Clip name =" + clip.name + "---->" + letterName);
				if (clip.name.Equals (letterName)) {
					soundSource.clip = clip;
					soundSource.Play ();

					break;
				}
			}
		}
	}
	public void StopSound(){
		if (soundSource != null) {
			soundSource.Stop ();
			soundSource.clip = null;

		}


	}
	public void muteSound(){
		if (soundOn) {
			//Debug.Log(b.image.sprite.name);
			b.image.sprite = s[0];
		} else {
			b.image.sprite = s[1];
		}

		if (soundSource != null) {
			if(soundOn)
				soundSource.Stop ();
			else
				soundSource.Play ();
			//soundSource.clip = null;	
		}
		soundOn = !soundOn;

	}

	public void ReplaySound(){
		if(soundSource != null)
			soundSource.Play ();
	}

}
