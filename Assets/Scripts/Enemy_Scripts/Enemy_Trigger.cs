using UnityEngine;
using System.Collections;

public class Enemy_Trigger : MonoBehaviour {
	
	//give this access to the enemy script
	Basic_Enemy enemy;
	Transform target;
	bool found = false;
	
	
	// Use this for initialization
	void Start () {
		enemy = transform.parent.gameObject.GetComponent<Basic_Enemy>();
		target = enemy.target;
	}
	
	void FixedUpdate(){
		
		}
		
	public void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player"){
			Debug.Log("ayylmao");
			enemy.active = true;
			enemy.target = target;
		}
		if(other.gameObject.tag == "Decoy"){
			enemy.target = target;
			enemy.active = false;
			Destroy(other.gameObject, 3);
		}
		
	}
	
	public void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Player"){
			Debug.Log("Goodbye");
			enemy.active = false;
		}
	}
	/*
	void OnTriggerStay2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
			RaycastHit2D hit = Physics2D.Raycast(transform.position, other.transform.position);
			if(hit.collider.gameObject.tag == "Player"){
				Debug.Log("I FOUND YOU!");
				enemy.active = true;
			}
		}
	}*/
}
