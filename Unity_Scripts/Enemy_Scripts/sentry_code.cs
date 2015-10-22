using UnityEngine;
using System.Collections;

//sentry enemy, rotates to face the player then fires projectiles

public class sentry_code : MonoBehaviour {
	
	public Transform target;
	public GameObject projectile;
	
	public bool activation = false;
	public ParticleSystem destruction;
	public int hp = 5;
	float timer = 1;
	float rotation_speed = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(activation){
			//Debug.Log("success");
			//calculate the rotation needed 
			Quaternion needed_rotation = Quaternion.LookRotation(target.position-transform.position);

			//use spherical interpollation over time 
			transform.rotation = 
			Quaternion.Slerp(transform.rotation, needed_rotation, Time.deltaTime*rotation_speed);
			
			//transform.LookAt(target);
			
			if(timer<=0){
				Instantiate(projectile, transform.position+transform.forward*1.5f, transform.rotation);
				timer = 0.5f;
			}
			timer-=Time.deltaTime;
		}
		else{
			timer = 1;
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
	
	void Death(){
		Debug.Log("why");
		Instantiate(destruction, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}