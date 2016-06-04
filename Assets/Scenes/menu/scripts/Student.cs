using UnityEngine;
using System.Collections;
using SimpleJSON;

public class Student : MonoBehaviour {

	public int id { get; set;}
	public string name { get; set;}
	public string gender { get; set;}
//	public int last_scene;
//	public int last_object_total;

	public Student(int id){
		this.id = id;
		Debug.Log("new Student");
	}

	public Student(int id, string name, string gender){
		this.id = id;
		SetName (name);
		SetGender (gender);

		Debug.Log("new Student");
	}
	// Use this for initialization
	void Start () {
//		Debug.Log("Student Start()");
//		Student.getRemoteStudent(1,(student) =>{
//			Debug.Log(student);
//		});
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static IEnumerator getRemoteStudent(int id, System.Action<object> callback){
		Debug.Log("getRemoteStudent");
		string url = "http://127.0.0.1:3000/api/student?id=" + id;

		WWW download = new WWW(url);
		yield return download;

		Student student = Student.CreateFromJSON(download.text);
//		Student student = Student.CreateFromJSON("{id:1,name:'name_name',gender:'M',last_scene:1,last_object_total:10}");
		callback(student);
	}

	public static Student CreateFromJSON(string jsonString){
		return JsonUtility.FromJson<Student>(jsonString);
	}

	public int GetId(){ return this.id; }
	public string GetName(){ return this.name; }
	public string GetGender(){ return this.gender; }

	public void SetId(int id){ this.id = id; }
	public void SetName(string name){ this.name = name; }
	public void SetGender(string gender){ this.gender = gender; }

//	public string ToString(){
//	}
}
