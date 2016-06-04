using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections.Generic;

public class SpawnObjectButtonControl : MonoBehaviour {

	//WTF IS UNITY DOING ?!?  CANNOT ASSIGN VALUE HERE ?!?
	//GameObject => Throw exception
	//bool => default False
	public GameObject button;// = GameObject.Find ("btnSpawnObject"); 
	public bool spawnObject;// = true;

	// Use this for initialization
	void Start () {
		button = GameObject.Find ("btnSpawnObject");
		spawnObject = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onBtnSpawnObjectClick(){
		//
		Debug.Log ("onBtnSpawnObjectClick()");
		if (spawnObject) {
			GameObject.Find ("txtSpawnObject").GetComponent<Text> ().text = "OFF";
			var localPos = button.GetComponent<Image> ().transform.localPosition;
			var x = localPos.x;
			var y = localPos.y;
			var z = localPos.z;
			button.GetComponent<Image> ().transform.localPosition = new Vector3(x-35,y,z);  //.position -= 30;
		} else {
			GameObject.Find ("txtSpawnObject").GetComponent<Text> ().text = "ON";
//			button.transform.transform   //.position += 30;

			var localPos = button.GetComponent<Image> ().transform.localPosition;
			var x = localPos.x;
			var y = localPos.y;
			var z = localPos.z;
			button.GetComponent<Image> ().transform.localPosition = new Vector3(x+35,y,z);
		}
		spawnObject = !spawnObject;

		
	}
}
