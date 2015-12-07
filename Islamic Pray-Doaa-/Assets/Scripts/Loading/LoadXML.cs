using UnityEngine;
using System.Collections;
using System.Xml;

public class LoadXML : MonoBehaviour {

	// Use this for initialization

	#region Singleton
	static LoadXML instance;
	public static LoadXML Instance
	{
		get
		{
			if (!instance)
				instance = new GameObject("LoadXML").AddComponent<LoadXML>();
			
			return instance;
		}
	}
	
	#endregion
	


	XmlDocument xmlFile;

	public void LoadFromXML()
	{
		
		//WWW www = new WWW(fileURL); ; 
		//Debug.Log("start Mostafa");
		// Debug.Log("Error" + www.error);
		WWW www = null;
		/*while (www == null || www.error != null)
		{
			www = new WWW(fileURL);
			yield return www;
			Debug.Log("Error Loading " + www.error);
		}*/

		TextAsset textAsset = (TextAsset)Resources.Load("LetterModels", typeof(TextAsset));
		
		//Debug.Log("END Mostafa");
		
		
		xmlFile = new XmlDocument();
		
		if (textAsset != null)
		{
			//Debug.Log("Sucessfully Loading URL : " );
			xmlFile.LoadXml(textAsset.text);			
		}
		else
		{
			//Debug.Log("Error Loading URL : " );
		}
		
	}

	void Awake()
	{
		//prevent multiple instances of singleton
		if (instance == null)
			instance = this;
		if (this != instance)
			Destroy(this);
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public string ModelName(string letterName){
		XmlNodeList nodes = null;
		if(xmlFile != null)
			nodes = xmlFile.SelectNodes("Letters/Letter");
		else
			Debug.Log("Error in xmlFile");

		Debug.Log ("Num Node : " + nodes.Count);

		foreach (XmlNode n in nodes)
		{

			if(n.Attributes.GetNamedItem("name").Value.Equals(letterName)){
				Debug.Log("HERE Model" + n.SelectSingleNode("ModelName").InnerText);
				return n.SelectSingleNode("ModelName").InnerText;
			}			
			
		}

		return null;

	}


}
