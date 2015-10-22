using UnityEngine;
using System.Collections;

public class RexTrigger : MonoBehaviour {

	public RexRacers racer;
	
	
	void start(){
		racer = GetComponent<RexRacers>();
		//anim = transform.root.GetComponent<Animator>();
	}

	//Once player makes contact with the collider
	public void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "player"){
			racer.activation = true;
		}
	}
	
	//Once player exits the collider
	public void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "player"){
			//Debug.Log("Goodbye");
			racer.activation = false;
		}
	}
}
