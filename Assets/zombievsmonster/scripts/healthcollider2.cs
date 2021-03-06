using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class healthcollider2 : MonoBehaviour {

	public AudioSource someSound1;
	public Image healthBar2;
	private int health;
	public GameObject RestartDialoug;
	private Animator anim, animOther;
	// Use this for initialization
	void Start () {
		anim = GameObject.FindGameObjectWithTag ("monster").GetComponent<Animator> ();
		animOther = GameObject.FindGameObjectWithTag("zombie").GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		health = animOther.GetInteger ("HealthZombie");
		float healt = (float)health / 100.0f;
		healthBar2.rectTransform.localScale = new Vector3 (healt, healthBar2.rectTransform.localScale.y, healthBar2.rectTransform.localScale.z);
	}

	void OnTriggerEnter(Collider other){
		print ("Collider Hit");
		if (other.CompareTag ("zombie") && !Input.GetKey("left")){
			if (animOther.GetBool ("defence") == false && !Input.GetKey("down")&& !Input.GetKey("up")&& !Input.GetKey("left")) {
				SubtractHealth (4);
				animOther.SetBool ("wound", true);
				//someSound1.Play ();
			}
		}
	}
	void OnTriggerExit(Collider other){
		if (other.CompareTag ("zombie") && !Input.GetKey("left")){
			animOther.SetBool ("wound",false);
		}
	}
	public void SubtractHealth(int amount){
		health = animOther.GetInteger ("HealthZombie");
		if (health-amount <=0){
			health = 0;
			animOther.SetInteger ("HealthZombie", health);
		} else {
			health -= amount;
			//print ("Health: " + health);
			animOther.SetInteger ("HealthZombie", health);
		}
	}
	public void Restart(){
		//Application.LoadLevel (Application.loadedLevel);
	}
}
