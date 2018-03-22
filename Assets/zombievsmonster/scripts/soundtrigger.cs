using UnityEngine;
using System.Collections;

public class soundtrigger : MonoBehaviour {

	public AudioSource someSound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("q") || Input.GetKeyDown ("e")) {
			someSound.Play ();
		
		}
	
	}
}
