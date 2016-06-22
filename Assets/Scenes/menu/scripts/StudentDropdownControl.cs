using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections.Generic;

public class StudentDropdownControl : MonoBehaviour {

	public Dropdown mydd;
	static List<Student> studentList = new List<Student>();

	// Use this for initialization
	void Start () {
		
		//Get list of students
		AsyncTask asyncTask = gameObject.AddComponent<AsyncTask>();
		asyncTask.SetUrl ("https://sunnywalk.herokuapp.com/api/student/all.json")
			.AddQueryParams ("token", "dzfdmpkumxqqgnadd")
			.AddQueryParams ("secret", "Uor593YqX58xiZGJRAJOlGAtvH6pVIUGkiBxAQfooe0=")
			.Before((t) => { 
				AsyncTask task = (AsyncTask) t;
				Debug.Log("[TRACE][ASYNCTASK] " + task.GetUrl() + task.GetQueryParams());
			})
			.Progress((p) => { 
				float progress;
				float.TryParse(p.ToString(), out progress);
				Debug.Log("[TRACE][ASYNCTASK] Progress: " + (progress * 100) + "%"); 
			})
			.After((data) => { 
				WWW download = (WWW) data;
				//Debug.Log("[INFO][ASYNCTASK] Downloaded: " + download.text); 
				if(string.IsNullOrEmpty(download.error)) {
					//success, response text
					Debug.Log(download.text);
					var jObj = JSON.Parse(download.text);
					for (int i=0;i<jObj.Count;i++){
						InsertOption(jObj[i]["name"].Value);

						Student s = gameObject.AddComponent<Student>();
						s.SetId(jObj[i]["id"].AsInt);
						s.SetName(jObj[i]["name"].Value);
						s.SetGender(jObj[i]["gender"].Value);

						studentList.Add(s);
					}
				} else {
					Debug.Log ( "Error downloading: " + download.error );
				}
			}).Start();
	}
	
	// Update is called once per frame
	void Update () {

	}

	/**
	 * Insert new item to dropdown
	 * @params text - the text will show on the dropdown list option
	 * @return void
	 **/
	public void InsertOption(string text){
		Dropdown.OptionData optionData = new Dropdown.OptionData();
		optionData.text = text;
		mydd.options.Add (optionData);
	}

	/**
	 * Trigger when dropdown value changed
	 * @return void
	 **/
	public void dd_value_changed(){
		Student s = GetSelectedStudent();
		Main.currentStudent = s;
		if (s == null) {
			Debug.Log ("Selected index 0");
		} else {
			Debug.Log ("You selected " + s.GetName() + ", ID is " + s.GetId());
		}
	}

	/**
	 * Get students list
	 * @return List<Student>  - students in `System.Collections.Generic.List`
	 **/
	public static List<Student> GetStudentList(){
		return studentList;
	}

	/**
	 * Get selected student
	 * @return Student
	 **/
	public Student GetSelectedStudent(){
		if (mydd.value > 0) {
			return studentList[mydd.value-1];
		} else {
			return null;
		}
	}
}
