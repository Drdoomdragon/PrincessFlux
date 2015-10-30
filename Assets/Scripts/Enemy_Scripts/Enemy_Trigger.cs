using UnityEngine;
using System.Collections;

public class Enemy_Trigger : MonoBehaviour {
	
	//give this access to the enemy script
	Basic_Enemy enemy;
	bool found = false;
	
	
	// Use this for initialization
	void Start () {
		enemy = transform.parent.gameObject.GetComponent<Basic_Enemy>();
	}
	
	void FixedUpdate(){
		
		}
	
	public void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player"){
			Debug.Log("ayylmao");
			enemy.active = true;
		}
	}
	
	public void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Player"){
			Debug.Log("Goodbye");
			enemy.active = false;
			//enemy.restartPatrol();
		}
	}
}
