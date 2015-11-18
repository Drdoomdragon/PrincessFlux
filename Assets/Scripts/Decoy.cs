using UnityEngine;
using System.Collections;

public class Decoy : MonoBehaviour {
	
	Basic_Enemy enemy_script;
	
	//set hostile all enemies within range, with this object as their target
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D enemy){
		if(enemy.gameObject.tag == "Enemy"){
			enemy_script = enemy.gameObject.GetComponent<Basic_Enemy>();
			enemy_script.target = this.transform;
			enemy_script.active = true;
		}
		if(enemy.gameObject.tag == "Boss"){
			
		}
	}
}
