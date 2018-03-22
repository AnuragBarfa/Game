using UnityEngine;
using System.Collections;

public class pause : MonoBehaviour {
	public GameObject thePanel;
	public void pauseGame()
	{
		Time.timeScale = 0;
		thePanel.SetActive (true);
	}
	public void unPauseGame()
	{
		Time.timeScale = 1;
		thePanel.SetActive (false);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
