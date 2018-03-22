using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class healthCollider : MonoBehaviour {

	public Image healthBar;
	public int health;
	private Animator anim;
	private Animator animOther;
	bool close=false;
	public GameObject RestartDialoug;
	public GameObject gameendpanel;


	// Use this for initialization
	void Start () {
		animOther = GameObject.FindGameObjectWithTag ("monster").GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		health = animOther.GetInteger ("HealthMonster");
		float healt = (float)health / 100.0f;
		healthBar.rectTransform.localScale = new Vector3 (healt, healthBar.rectTransform.localScale.y, healthBar.rectTransform.localScale.z);
		if(health <=0.0){
			//ShowRestartDialoug(true);public void unPauseGame()
			gameendpanel.SetActive (true);
		}
	}

	void OnTriggerEnter(Collider other){
		print ("Collider Hit");
		if (other.CompareTag ("monster") && !Input.GetKey("d")){
			if (animOther.GetBool ("defence") == false && !Input.GetKey("s") && !Input.GetKey("d")&& !Input.GetKey("a")&& animOther.GetBool("run")==false) {
				SubtractHealth (4);
				animOther.SetBool ("gotHit", true);
			}
		}
	}
	void OnTriggerExit(Collider other){
		if (other.CompareTag ("monster") && !Input.GetKey("d")){
			animOther.SetBool ("gotHit", false);
		}
	}
	public void SubtractHealth(int amount){
		health = animOther.GetInteger ("HealthMonster");
		if (health-amount <=0){
			//print ("Dead");
			health = 0;
			animOther.SetInteger ("HealthMonster", health);
		} else {
			health -= amount;
			//print ("Attacked: "+health);
			animOther.SetInteger ("HealthMonster",health);
		}
	}

	public void Restart(){
		Application.LoadLevel (Application.loadedLevel);
	}
}
