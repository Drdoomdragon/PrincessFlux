using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	public float speed = 100;
	public AudioClip blastershot;
	
	float timer = 0f;
	float volume = 0.5f;
	
	Rigidbody2D rb;
	AudioSource source;

	// Use this for initialization
	
	void Awake(){
		source = GetComponent<AudioSource>();
	}
	
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		//have it move straight ahead, the player spawning it will orientate it
		rb.velocity = speed*transform.forward;
		source.PlayOneShot(blastershot,volume);
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
