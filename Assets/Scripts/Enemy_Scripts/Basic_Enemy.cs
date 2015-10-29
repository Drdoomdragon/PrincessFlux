using UnityEngine;
using System.Collections;

public class Basic_Enemy : MonoBehaviour {
	
	public Transform target;
	public Transform[] locations;
	public Animator animator;
	
	public bool active = false;
	
	//health and motion speed of the enemy
	public int hp = 3;
	float movespeed = 0.5f;
	float dashspeed = 1.5f;
	
	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
		StartCoroutine(Patrol());
	}
	
	// Update is called once per frame
	void Update () {
		
		if(active){
			//Debug.Log("success");
			//player has entered the trigger zone, move from passive to active
			animator.Play("alerted");
			if(transform.position!=target.position){
			transform.position = Vector2.MoveTowards(transform.position, target.position,
			dashspeed*Time.deltaTime);
			}
		}
		else{
			//passive AI behaviour 
			animator.Play("idle");
		}
	}
	
	void FixedUpdate(){
		
	}
	
	IEnumerator Patrol(){
		do{
			foreach(Transform location in locations){
				yield return StartCoroutine(Route(location));
				if(active)
					break;
				yield return new WaitForSeconds(1f);
				
			}
		}while(!active);
	}
	
	IEnumerator Route(Transform location){
		while(transform.position!=location.position){
			transform.position = Vector2.MoveTowards(transform.position, location.position,
			movespeed*Time.deltaTime);
			if(active)
				break;
			yield return null; //call next frame, return here
		}
	}
	
	public void restartPatrol(){
		StartCoroutine(Patrol());
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
