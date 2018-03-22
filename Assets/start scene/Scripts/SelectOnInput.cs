using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SelectOnInput : MonoBehaviour {
	public EventSystem eventSystem;
	public GameObject selectedObjects;

	private bool buttonSelected;

	void Start ()
	{
	}

	void Update ()
	{
		if (Input.GetAxisRaw ("vertical") != 0 && buttonSelected == false) {
			//eventSystem.SetSelectedGameObject (selectedobject);
			buttonSelected = true;
		}
	}

	private void OnDisable ()
	{
		buttonSelected = false;
	}
}












































