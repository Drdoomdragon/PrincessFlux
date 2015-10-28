using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	public float speed = 100;
	float timer = 0f;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		//have it move straight ahead, the player spawning it will orientate it
		rb.velocity = speed*transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
		if(timer>2){
			Destroy(this.gameObject);
		}
		timer+=Time.deltaTime;
	}
	
	void OnCollisionEnter2D(Collision2D beta){
		if(beta.gameObject.tag!="Player"){
			Destroy(this.gameObject);
		}
	}
	
}
