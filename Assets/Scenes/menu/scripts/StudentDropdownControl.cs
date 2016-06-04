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

		AsyncStudentsInfoGetter infoGetter = gameObject.AddComponent<AsyncStudentsInfoGetter>();
		infoGetter.SetCallback((data) => {
			WWW download = (WWW)data;
			if(string.IsNullOrEmpty(download.error)) {
				//response text
				Debug.Log(download.text);
				var jObj = JSON.Parse(download.text);
				for (int i=0;i<jObj.Count;i++){
					InsertOption(jObj[i]["name"].Value);
				
					Student s = gameObject.AddComponent<Student>(); //CANNOT USE `new Student()` (will return null) ?!?
					s.SetId(jObj[i]["id"].AsInt);
					s.SetName(jObj[i]["name"].Value);
					s.SetGender(jObj[i]["gender"].Value);

					studentList.Add(s);

					Debug.Log("ToString: " + s.ToString());
					Debug.Log(studentList[studentList.Count-1]);
				}


//				GameObject.Find("studentList").GetComponent<Text>().text = "Getted Student:\n ID:" + studInfo.id + " Name:" + studInfo.name;
			} else {
				print( "Error downloading: " + download.error );
			}

		}).Start(); 


	}
	
	// Update is called once per frame
	void Update () {

	}

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
