using UnityEngine;
using System.Collections;

public class monster : MonoBehaviour {
	Animator anim;
	Animator animOther;
	float speed=2f;
	public float health, thrust = 20.0f;
	private bool check = true,pick=false;
	private Rigidbody rb;
	private GameObject pickObj;
	bool right=true;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		animOther = GameObject.FindGameObjectWithTag ("zombie").GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update ()
	{
		if( pick==true && Input.GetKeyDown("p")){
			rb = pickObj.GetComponent<Rigidbody> ();
			rb.velocity = new Vector3(-10,0,0);
		}else if (pick == true && Input.GetKey("p")) {
			print ("tryin");
			pickObj.transform.position = new Vector3 (transform.position.x,4,transform.position.z);
		}
		if ((Input.GetKey ("right") || Input.GetKey ("left")) && anim.GetBool("die")==false && animOther.GetBool("idle0ToDeath")==false && check) {
			anim.SetBool ("walk far", true);
			transform.Translate (new Vector3 (0, 0, speed) * Time.deltaTime);
		}
		if (Input.GetKeyUp ("right") || Input.GetKeyUp ("left")) {
			anim.SetBool ("walk far", false);
		}
		if (Input.GetKeyDown ("right")  && right==true) {
			transform.Rotate (Vector3.up * 180);
			right=false;
		}if (Input.GetKeyDown ("left")  && right==false) {
			transform.Rotate (Vector3.up * 180);
			right=true;
		}
			if (Input.GetKey ("k")) {
				anim.SetBool ("kick", true);

			}
			if (Input.GetKeyUp ("k")) {
				anim.SetBool ("kick", false);
			}
			if (Input.GetKey ("up")) {
				anim.SetBool ("jump", true);

			}
			if (Input.GetKeyUp ("up")) {
				anim.SetBool ("jump", false);
			}
			if (Input.GetKey ("l")) {
				anim.SetBool ("2hand at", true);

			}
			if (Input.GetKeyUp ("l")) {
				anim.SetBool ("2hand at", false);


			}
			if (Input.GetKey ("j")) {
				anim.SetBool ("1by1hand at", true);

			}
			if (Input.GetKeyUp ("j")) {
				anim.SetBool ("1by1hand at", false);


			}
			if (Input.GetKey (",")) {
				anim.SetBool ("walk lef", true);
				transform.Translate (new Vector3 (speed, 0,0) * Time.deltaTime);
			}
			if (Input.GetKeyUp (",")) {
				anim.SetBool ("walk lef", false);


			}
			if (Input.GetKey (".")) {
				anim.SetBool ("walk rig", true);
				transform.Translate (new Vector3 (-speed, 0,0 ) * Time.deltaTime);

			}
			if (Input.GetKeyUp (".")) {
				anim.SetBool ("walk rig", false);
			}
		if(Input.GetKey("down")){
			anim.SetBool ("defence",true);
		}else if(Input.GetKeyUp("down")){
			anim.SetBool ("defence",false);
		}
	}
	void OnTriggerEnter(Collider other){
		print ("Collider Hit");
		if (other.CompareTag ("zombie")){
			check = false;
		}
		if (other.CompareTag ("pick")) {
			print ("collided");
			pick = true;
			pickObj = other.gameObject;
		}
	}
	void OnTriggerExit(Collider other){
		print ("Collider Hit");
		if (other.CompareTag ("zombie")){
			check = true;
		}
		if (other.CompareTag ("pick")) {
			print ("collided");
			pick = false;
		}
	}



}

