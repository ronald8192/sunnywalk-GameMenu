using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneDropdownControl : MonoBehaviour {

	public Dropdown sceneDropdown;

	// Use this for initialization
	void Start () {
		sceneDropdown = GameObject.Find ("DropdownSceneList").GetComponent<Dropdown>();
		sceneDropdown.onValueChanged.AddListener(delegate {
			onChange();
		});
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onChange(){
		Main.scene = sceneDropdown.value + 1;
	}
}
