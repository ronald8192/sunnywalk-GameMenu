using UnityEngine;
using System.Collections;

public class AsyncGameResultUploader : MonoBehaviour {
	string url = "http://domain.com/api/game_result/new?";
	string queryParams = "";
	System.Action<object> callback;

	public AsyncGameResultUploader SetCallback(System.Action<object> callback){
		this.callback = callback;
		return this;
	}

	// Use this for initialization
	public IEnumerator Start () {
		AddQueryParams("student_id", Main.currentStudent.GetId() + "");
		AddQueryParams("duration", 300 + "");      //change to your value
		AddQueryParams("object_total", 999 + "");  //change to your value
		AddQueryParams("object_caught", 99 + "");  //change to your value

		Debug.Log("Upload game result: " + url + queryParams);
		WWW download = new WWW( url + queryParams );
		yield return download;
		callback(download);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/**
	 * GET
	 * construct query string (helper)
	 **/
	public string AddQueryParams(string key, string value){
		queryParams += WWW.EscapeURL(key) + "=" + WWW.EscapeURL(value) + "&";
		return queryParams;
	}
}
