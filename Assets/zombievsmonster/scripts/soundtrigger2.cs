using UnityEngine;
using System.Collections;

public class soundtrigger2 : MonoBehaviour {

	public AudioSource someSound;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("a") || Input.GetKeyDown ("d")) {
			someSound.Play ();

		}

	}
}
