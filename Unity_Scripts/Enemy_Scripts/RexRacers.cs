using UnityEngine;
using System.Collections;

//speeds forwards towards the player, slowly turns, very long but narrow trigger box

public class RexRacers : MonoBehaviour {

	public Transform target;
	
	public bool activation = false;
	public ParticleSystem destruction;
	public int hp = 1;
	float movespeed = 10;
	float rotation_speed = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(activation){
			//Debug.Log("success");
			transform.position = Vector3.MoveTowards(transform.position, target.position,
			movespeed*Time.deltaTime);
			
			Quaternion needed_rotation = Quaternion.LookRotation(target.position-transform.position);
 
			transform.rotation = 
			Quaternion.Slerp(transform.rotation, needed_rotation, Time.deltaTime*rotation_speed);
		}
		else{
			
			
		}
	}
	void OnCollisionEnter(Collision beta){
		Debug.Log("smack");
		if(beta.gameObject.tag == "weapon"||beta.gameObject.tag == "projectile"){
			hp-=1;
		}
		if(hp<=0){
			Death();
		}
	}
	
	void OnTriggerEnter(Collider gamma){
		if(gamma.gameObject.tag == "barrier"){
			Death();
		}
	}
	
	void Death(){
		Debug.Log("hmph...");
		Instantiate(destruction, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
