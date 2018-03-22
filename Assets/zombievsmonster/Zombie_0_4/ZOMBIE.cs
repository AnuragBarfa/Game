using UnityEngine;
using System.Collections;

public class ZOMBIE : MonoBehaviour {
	public static float MAX_HEALTH = 100f;
	public float healt = MAX_HEALTH;
	private bool check=true;
	private Rigidbody rb;
	private bool pick=false;
	private GameObject pickObj;
	public string FighterName;
	private Animator animOther;
	public ZOMBIE oponent;
	float speed=4.0f;
	private int health;
	bool right=true;
	Animator anim;
	private Rigidbody myBody;
	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator>();
		animOther = GameObject.FindGameObjectWithTag ("monster").GetComponent<Animator> ();
	}
	//zand c for left right movement

	// Update is called once per frame
	void Update ()
	{

		anim.SetFloat ("health", healtPercent);

		if( pick==true && Input.GetKeyDown("f")){
			rb = pickObj.GetComponent<Rigidbody> ();
			rb.velocity = new Vector3(10,0,0);
		}else if (pick == true && Input.GetKey("f")) {
			print ("tryin");
			pickObj.transform.position = new Vector3 (transform.position.x,4,transform.position.z);
		}
		if (oponent != null) {

			anim.SetFloat ("oponent_health", oponent.healtPercent);
		} else {
			anim.SetFloat ("oponent_health", 1);
			if ((Input.GetKey ("d") || Input.GetKey ("a")) && animOther.GetBool("die")==false && anim.GetBool("idle0ToDeath")==false) {
				anim.SetBool ("idle0ToRun", true);
				transform.Translate (new Vector3 (0, 0, speed) * Time.deltaTime);
			}
			if ((Input.GetKeyUp ("d") || Input.GetKeyUp ("a"))) {
				anim.SetBool ("idle0ToRun", false);
			}
			if(Input.GetKeyDown("s")){
				anim.Play ("jump");
			}
			if(Input.GetKeyUp("s")){
				anim.SetBool ("jump",false);
			}
			if (Input.GetKeyDown ("a")  && right==true && animOther.GetBool("die")==false && anim.GetBool("idle0ToDeath")==false) {
				transform.Rotate (Vector3.up * 180);
				right=false;
			}if (Input.GetKeyDown ("d")  && right==false && animOther.GetBool("die")==false && anim.GetBool("idle0ToDeath")==false) {
				transform.Rotate (Vector3.up * 180);
				right=true;
			}
			{
				if (Input.GetKeyDown ("q")) {
					anim.SetBool ("idle0ToAttack1", true);
				}
				if (Input.GetKeyUp ("q")) {
					anim.SetBool ("idle0ToAttack1", false);
				}
				if (Input.GetKey ("w")) {
					anim.SetBool ("idle0ToSkill0", true);
				}
				if (Input.GetKeyUp ("w")) {
					anim.SetBool ("idle0ToSkill0", false);
				}
				if (Input.GetKey ("e")) {
					anim.SetBool ("idle0ToAttack0", true);

				}
				if (Input.GetKeyUp ("e")) {
					anim.SetBool ("idle0ToAttack0", false);


				}

				if (Input.GetKey ("z")) {
					anim.SetBool ("idle0ToRun", true);
					transform.Translate (new Vector3 (speed, 0, 0) * Time.deltaTime);
				}
				if (Input.GetKeyUp ("z")) {
					anim.SetBool ("idle0ToRun", false);


				}
				if (Input.GetKey ("c")) {
					anim.SetBool ("idle0ToRun", true);
					transform.Translate (new Vector3 (-speed, 0, 0) * Time.deltaTime);

				}
				if (Input.GetKeyUp ("c")) {
					anim.SetBool ("idle0ToRun", false);
				}
				if (Input.GetKeyDown ("s")) {
					anim.SetBool ("defence",true);
				}

				if (Input.GetKeyUp ("s")) {
					anim.SetBool ("defence",false);
				}
			}
		}
	}
	/*void OnTriggerEnter(Collider other){
		if(other.CompareTag("pick")){
			health = anim.GetInteger ("HealthZombie");
			health -= 2;
			anim.SetInteger ("HealthZombie",health);
		}
	}*/
	public float healtPercent {
		get {
				return healt/MAX_HEALTH;
			}
	}
		public Rigidbody body
		{
			get{
				return this.myBody;
			}
		}


	void OnTriggerEnter(Collider other){
		//print ("Collider Hit");
		if (other.CompareTag ("pick")) {
			//print ("collided");
			pick = true;
			pickObj = other.gameObject;
		}
	}

	void OnTriggerExit(Collider other){
		//print ("Collider Hit");
		if (other.CompareTag ("pick")) {
			//print ("collided");
			pick = false;
		}
	}
}

