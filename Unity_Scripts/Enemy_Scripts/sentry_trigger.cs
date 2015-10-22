using UnityEngine;
using System.Collections;

public class sentry_trigger : MonoBehaviour {
	//Trigger for the sentry, non-moving just a detector
	// Use this for initialization
	public sentry_code enemycode;
	Animator anim;
	
	
	void start(){
		enemycode = GetComponent<sentry_code>();
		anim = transform.root.GetComponent<Animator>();
	}

	//Once player makes contact with the collider
	public void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "player"){
			//Debug.Log("ayylmao");
			enemycode.activation = true;
			//anim.Play("OnionDetect");
		}
	}
	
	//Once player exits the collider
	public void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "player"){
			//Debug.Log("Goodbye");
			enemycode.activation = false;
		}
	}
}
