using UnityEngine;
using System.Collections;
using SimpleJSON;

public class Main : MonoBehaviour {

	//Menu settings
	public static Student currentStudent;
	public static bool spawnObject;
	public static int scene;


	// Use this for initialization
	void Start () {
		currentStudent = null;
		spawnObject = true;
		scene = 1;

		//test
//		Debug.Log("a" == "a"); //true
//		Debug.Log("a" == "b");//false
//		Debug.Log(string.Compare("a","a")); //0
//		Debug.Log(string.Compare("a","b")); //-1
//		Debug.Log(string.Compare("b","a")); //1

//		SimpleJSON example
//		var json = "{\"version\": \"1.0\",\"data\":{\"sampleArray\":[\"string value\",5,{\"name\": \"sub object\"}]}}";
//		var N = JSON.Parse(json);
//		var versionString = N["version"].Value;        // versionString will be a string containing "1.0"
//		var versionNumber = N["version"].AsFloat;      // versionNumber will be a float containing 1.0
//		var name = N["data"]["sampleArray"][2]["name"];// name will be a string containing "sub object"
//
//		Debug.Log("versionString: " + versionString);
//		Debug.Log("versionNumber: " + versionNumber);
//		Debug.Log("name: " + name);
//
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void OnGameFinish(){
		//create a new AsyncGameResultUploader
		AsyncGameResultUploader resultUploader = gameObject.AddComponent<AsyncGameResultUploader> ();

		//set callback, return WWW as object in `wwwObj`
		resultUploader.SetCallback ((wwwObj) => {
			WWW download = (WWW)wwwObj;

			if(string.IsNullOrEmpty(download.error)) {
				var jObj = JSON.Parse(download.text);
				if(jObj["status"].Value == "OK"){
					//success


				}else{
					//failed, usually missing some params


				}

			}else{
				Debug.Log( "Upload game result error: " + download.error );
			}
		}).Start();
	}
}
