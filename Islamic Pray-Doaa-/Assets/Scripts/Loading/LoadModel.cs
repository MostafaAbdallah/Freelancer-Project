using UnityEngine;
using System.Collections;

public class LoadModel : MonoBehaviour {

	#region Singleton
	static LoadModel instance;
	public static LoadModel Instance
	{
		get
		{
			if (!instance)
				instance = new GameObject("LoadModel").AddComponent<LoadModel>();
			
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


	public GameObject LoadFromRescources(string modelName){

		GameObject newModel = Resources.Load (modelName)as GameObject;

		GameObject letterModel = Instantiate (newModel, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
		letterModel.name = modelName;

		return letterModel;

	}

}
