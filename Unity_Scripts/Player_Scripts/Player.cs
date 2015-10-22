using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public GameObject projectile;
	public GameObject weapon;
	
	Rigidbody corps;
	
	public bool combat = true;
	public bool mouse_aim = false;
	bool jump = false;
	bool dash = false;
	bool attack = false;
	
	public float movement_speed = 10;
	public float turn_speed = 60;
	public float cruise_speed = 30;
	public float mouse_turn_speed = 15;
	
	float TIME = 0f;
	float dashtime = 0.5f;
	
	float Vmove;
	float Hmove;
	float cooldown = 0.25f;

	
	int hp = 10;
	float attack_time = 2;
	float attk_cooldown = 3;
	float jump_cooldown = 3;
	float dash_cooldown = 3;
	float transform_cooldown = 3;
	
	float boost = 4;
	
	float horizontal;

	// Use this for initialization
	void Awake () {
		corps = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		//add a cooldown
		if (combat){
		//float horizontal = Input.GetAxis("Horizontal") * turn_speed * Time.deltaTime;
		//float horizontal = Input.GetAxis("Mouse X") * mouse_turn_speed * Time.deltaTime;
		
		if(mouse_aim){
			horizontal = Input.GetAxis("Mouse X") * mouse_turn_speed;
			transform.Rotate(0, horizontal, 0);
		}
		else{
			horizontal = Input.GetAxis("Horizontal") * turn_speed * Time.deltaTime;
			transform.Rotate(0, horizontal, 0);
		}
         
        float vertical = Input.GetAxis("Vertical") * movement_speed * Time.deltaTime;
        transform.Translate(0, 0, vertical);
		}
		else{
			Vmove = Input.GetAxis("Vertical");
			
			if(Vmove>0){
				corps.velocity = (corps.velocity.x-6)*transform.forward;
				if(corps.velocity.x<cruise_speed/2){
					corps.velocity = (cruise_speed/2)*transform.forward;
				}
				
			}
			else if(Vmove<0){
				corps.velocity = (corps.velocity.x+3)*transform.forward;
				if(corps.velocity.x>cruise_speed*2){
					corps.velocity = cruise_speed*transform.forward;
				}
			}
			
			else{
				float vertical = movement_speed * Time.deltaTime;
				transform.Translate(0, 0, vertical);
			}
			
			float horizontal = Input.GetAxis("Horizontal") * turn_speed * Time.deltaTime;
			transform.Rotate(0, horizontal, 0);
		
		}
		
		//the dash
		Hmove = Input.GetAxis("Horizontal");
		Vmove = Input.GetAxis("Vertical");
		
		if(cooldown>0){
			cooldown-=1*Time.deltaTime;
		}
		
		
		//the combat button
		if(Input.GetButton("Fire1")&&attk_cooldown>3){
			Instantiate(projectile, transform.position+transform.forward*1.5f, transform.rotation);
			//Debug.Log("Pew");
			attk_cooldown-=1;
		}
		
		if(Input.GetButton("Fire2")&&attk_cooldown>3){
			attack = true;
			Debug.Log("MELEEE!");
			attk_cooldown-=2;
		}
		
		//transformation, change mesh, play animation, whatever
		if(Input.GetButton("Fire3")&&transform_cooldown>3){
			combat = !combat;
			if(!combat){
				corps.velocity = cruise_speed*transform.forward;
			}
			else{
				corps.velocity = (cruise_speed/2)*transform.forward;
			}
			Debug.Log("Transform?!");
			transform_cooldown = 0;
		}
		
		//jump button
		if(Input.GetButton("Jump")&&jump_cooldown>3){
			jump = true;
			jump_cooldown-=1.5f;
			Debug.Log("JUMPU");
		}
		
		
		//regen
		attk_cooldown+=1*Time.deltaTime;
		transform_cooldown+=1*Time.deltaTime;
		jump_cooldown+=1*Time.deltaTime;
		dash_cooldown+=1*Time.deltaTime;
		boost += 2*Time.deltaTime;
		
		//setting the position back to normal if it rotates too much
		if(transform.eulerAngles.x>40||transform.eulerAngles.z>40){
			transform.eulerAngles = new Vector3(0, transform.eulerAngles.y,0);
		}
	}
	
	void FixedUpdate(){
		if(jump){
			if(combat){
				corps.AddForce(new Vector3(0,80f,0));
			}
			else{
				corps.AddForce(new Vector3(Vmove*500f,Hmove*100f,0));
			}
			jump = false;
		}
		
		if(dash){
			dash = false;
			StartCoroutine(quick_attack());
			TIME = 0f;
			Debug.Log("zoom");
		}
		
		if(attack){
			StartCoroutine(strike());
			attack_time = 2;
		}
	}
	
	IEnumerator strike(){
		while(attack_time>0){
			//play animation
			gameObject.tag = "weapon";
			attack_time-=Time.deltaTime;
			yield return null;
		}
		gameObject.tag = "player";
	}
	
	IEnumerator quick_attack(){
		while(dashtime>TIME){
			
			if(combat){
				
			}
			else{
				
			}
			float dash_move = this.transform.localScale.x;
			gameObject.tag = "weapon";
			
			TIME+=1*Time.deltaTime;
			yield return null;
		}
		gameObject.tag = "player";
	}
	
	void OnCollisionEnter (Collision col){
		if(col.gameObject.tag == "projectile"||col.gameObject.tag == "enemy"||
		col.gameObject.tag == "rival"){
			hp -=1;
			if(hp<=0)
				Death();
		}

	}
	
	
	void Death(){
		Debug.Log("whyyyyyy");
		Destroy(this.gameObject,2);
	}
}
