using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClickBall : MonoBehaviour {

	// Use this for initialization
	void Start () {
//		Debug.Log("[TRACE] start");
//
//		StudentInfoGetter infoGetter = gameObject.AddComponent<StudentInfoGetter>();
//		infoGetter.SetCallback((data) => {
//			WWW download = (WWW)data;
//			if(string.IsNullOrEmpty(download.error)) {
//				//response text
//				Debug.Log(download.text);
//
//				//create object from JSON, see `StudentInfo` class
//				//StudentInfo studInfo = StudentInfo.CreateFromJSON(download.text);
//				StudentInfo studInfo = StudentInfo.CreateFromJSON("{\"id\":1,\"name\":\"name_name\",\"gender\":\"M\",\"last_scene\":1,\"last_object_total\":10}");
//
//				// output student info to console
//				Debug.Log("ID: " + studInfo.id);
//				Debug.Log("Name: " + studInfo.name);
//				Debug.Log("Gender: " + studInfo.gender);
//				GameObject.Find("studentList").GetComponent<Text>().text = "Getted Student:\n ID:" + studInfo.id + " Name:" + studInfo.name;
//			} else {
//				print( "Error downloading: " + download.error );
//			}
//
//		}).Start(); 
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("[TRACE] update");
		if(Input.GetMouseButtonDown(0)){
			Debug.Log("Pressed left click.");

			// your task 
			
		}
	}

	
}

public class StudentInfoGetter : MonoBehaviour {
	string url = "http://sunnywalk.herokuapp.com/api/student/one.json?"; // http://aaa.com/api/student?xxx=yyy&sss=uuu&
	string queryParams = "";
	System.Action<object> callback;

	public StudentInfoGetter SetCallback(System.Action<object> callback){
		this.callback = callback;
		return this;
	}

	public IEnumerator Start() {
		//POST method
		//WWWForm form = new WWWForm();
		//form.AddField("id", "574410b08e33397b4a000005");
		//form.AddField("score", "999");
		//WWW download = new WWW( url, form );

		//GET method
		//get student info with id 574410b08e33397b4a000005 
		AddQueryParams("id","1");
		Debug.Log("download data from: " + url + queryParams);
		WWW download = new WWW( url + queryParams );

		// Wait until the download is done
		yield return download;
		callback(download);
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


public class StudentInfo{
	public int id;
	public string name;
	public string gender;
	public int last_scene;
	public int last_object_total;
	
	public static StudentInfo CreateFromJSON(string jsonString){
		return JsonUtility.FromJson<StudentInfo>(jsonString);
	}
}