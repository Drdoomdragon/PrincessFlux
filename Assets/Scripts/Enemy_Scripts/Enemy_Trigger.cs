using UnityEngine;
using System.Collections;

public class Enemy_Trigger : MonoBehaviour {
	
	//give this access to the enemy script
	public Basic_Enemy enemy;
	
	
	// Use this for initialization
	void Start () {
		enemy = GetComponent<Basic_Enemy>();
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
		}
	}
}
