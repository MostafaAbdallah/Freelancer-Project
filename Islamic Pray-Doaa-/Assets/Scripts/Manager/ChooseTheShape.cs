using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChooseTheShape : MonoBehaviour {

	#region Singleton
	static ChooseTheShape instance;
	public static ChooseTheShape Instance
	{
		get
		{
			if (!instance)
				instance = new GameObject("ChooseTheShape").AddComponent<ChooseTheShape>();
			
			return instance;
		}
	}
	
	#endregion
	


	public Text objectName;
	public Button[] choices;

	public Sprite[] shapes;
	public string[] modelNames;

	void Awake()
	{
		//prevent multiple instances of singleton
		if (instance == null)
			instance = this;
		if (this != instance)
			Destroy(this);
	}

	public int initGame(){

		int chooseNameIndex = Random.Range (0, (modelNames.Length));
		objectName.GetComponent<FixGUITextCS>().text = modelNames[chooseNameIndex];
		objectName.GetComponent<FixGUITextCS> ().UpdateText ();
		int correctAnswerIndex = Random.Range (0, (choices.Length));

		Debug.Log("startGame with name = " + modelNames[chooseNameIndex]);
		Debug.Log("correctAnswerIndex " + correctAnswerIndex);

		int wrongAnswerIndex = chooseNameIndex;
		int FRIwrongAnswerIndex = -1;
		Debug.Log ("sprit name = " +  shapes [chooseNameIndex].name + "   ChooseNum = " + chooseNameIndex);
		choices [correctAnswerIndex].image.sprite = shapes [chooseNameIndex];
		foreach (Button b in choices) {
			if(b.image.sprite == null){
				while(wrongAnswerIndex == chooseNameIndex || wrongAnswerIndex == FRIwrongAnswerIndex){
					wrongAnswerIndex = Random.Range(0,shapes.Length);
				}
				FRIwrongAnswerIndex = wrongAnswerIndex;
				b.image.sprite = shapes[wrongAnswerIndex];
			}
		}

		return correctAnswerIndex;

	} 

	public void ResetGame(){
		foreach (Button b in choices) {
			b.image.sprite = null;
		}
		objectName.GetComponent<FixGUITextCS> ().text = null;
	}
}
