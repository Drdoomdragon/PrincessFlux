using UnityEngine;
using System.Collections;

public class Aggro_Trigger : MonoBehaviour {

//give this access to the enemy script
	//public Basic_Enemy enemy;
	
	
	// Use this for initialization
	void Start () {
		//enemy = transform.parent.gameObject.GetComponent<Basic_Enemy>();
	}
	
	public void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player"){
			//enemy.rage = true;
		}
	}
	
	public void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Player"){
			//enemy.rage = false;
		}
	}
}
