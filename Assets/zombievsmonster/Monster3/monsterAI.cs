using UnityEngine;
using System.Collections;

public class monsterAI : MonoBehaviour {
	Animator anim;
	Animator animOther;
	float speed=2f;
	public float health, thrust = 20.0f;
	private bool check = false,pick=false;
	private Rigidbody rb;
	private GameObject pickObj,otherObj;
	bool right=true;
	private int choice;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		otherObj = GameObject.FindGameObjectWithTag ("zombie");
		animOther = GameObject.FindGameObjectWithTag ("zombie").GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update ()
	{
		choice = Random.Range (0,100);
		if (choice>=2 && check==false) {
			print (check);
			anim.SetBool ("walk far", true);
			transform.Translate (new Vector3 (0, 0, speed) * Time.deltaTime);
		}
		if (choice<=1 && check==false) {
			transform.Rotate (Vector3.up * 180);
			//right=false;
		}
		if(check==true){
			anim.SetBool ("walk far", false);
			if (choice>=95) {
				anim.SetBool ("kick", true);
			}else if (choice>=90) {
				anim.SetBool ("kick", false);
			}/*else if(choice>=80){
				anim.SetBool ("defence",true);
			}*/
		}
	}
	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("zombie")){
			print ("Collid");
			check = true;
		}
	}
	void OnTriggerExit(Collider other){
		if (other.CompareTag ("zombie")){
			print ("Collid");
			check = false;
		}
	}



}

