using UnityEngine;
using System.Collections;

public class AsyncStudentsInfoGetter : MonoBehaviour {
	string url = "https://sunnywalk.herokuapp.com/api/student/all.json";
	System.Action<object> callback;

	public AsyncStudentsInfoGetter SetCallback(System.Action<object> callback){
		this.callback = callback;
		return this;
	}

	// Use this for initialization
	public IEnumerator Start() {
		Debug.Log ("[AsyncStudentsInfoGetter] download data from: " + url);
		WWW download = new WWW (url);

		yield return download;
		callback (download);

	}

	void Update () {
	
	}
}
