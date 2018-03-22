using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class soundtrigger3 : MonoBehaviour {

	public AudioSource someSound;
	// Use this for initialization
	void Start () {GameObject obj = GameObject.FindGameObjectWithTag ("fighter2");
		

	}

	// Update is called once per frame
	void Update () {
		
		}
	void OnTriggerEnter (Collider other)
	{
		
		if (other.CompareTag ("fighter2") && !Input.GetKey ("left")) {
			someSound.Play ();
		}
	}
}

