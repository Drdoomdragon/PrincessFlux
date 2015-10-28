﻿using UnityEngine;
using System.Collections;

public class Basic_Enemy : MonoBehaviour {
	
	public Transform target;
	public Animator animator;
	
	public bool active = false;
	
	//health and motion speed of the enemy
	public int hp = 3;
	float movespeed = 5;
	
	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(active){
			//Debug.Log("success");
			//player has entered the trigger zone, move from passive to active
			animator.Play("blob_transform");
		}
		else{
			//passive AI behaviour 
			animator.Play("idle");
		}
		
		
	}
	
	//when something collides with the enemy, if the tag is weapon or projectile
	//subtract hp
	//could also put this on the projectle or weapon themselves to allow varying
	//decriments of hp
	void OnCollisionEnter2D(Collision2D beta){
		Debug.Log("smack");
		if(beta.gameObject.tag == "weapon"||beta.gameObject.tag == "projectile"){
			hp-=1;
		}
		if(hp<=0){
			Death();
		}
	}
	
	
	void Death(){
		//call this when HP reaches 0
		Debug.Log("why");
		//instantiate some death animation, then destroy the game object
		//OR play an animation, then destroy the enemy after 3 seconds
		//Instantiate(destruction, transform.position, Quaternion.identity);
		animator.Play("death");
		Destroy(gameObject,3);
	}
}
