using UnityEngine;
using System.Collections;

public class MainCharacter : MonoBehaviour {

    private BoxCollider2D boxCollider;
    private Animator animator;

    private float inverseMoveTime;
    private float speed;
	
	//cooldown for when the player can fire their standard projectile
	float p_cooldown = 0.5f;
	
	public GameObject projectile;

    void Start () {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        speed = 1.0F;
    }
	
    void Update() {
        // basic iso movement
        int horizontal = 0; 
        int vertical = 0;


        horizontal = (int)(Input.GetAxisRaw("Horizontal"))*2; //mult by 2 becuase otherwise values seemed too small If we want to do it tile based 2 can be our tile size
        vertical = (int)(Input.GetAxisRaw("Vertical"))*2;

        Vector3 move = new Vector3(horizontal-vertical, (horizontal+vertical)/2, 0);
        transform.position += move * speed * Time.deltaTime;
		
		if(Input.GetButtonDown("Fire1")&&p_cooldown<0){
			fire();
			p_cooldown = 0.5f;
		}
		
		p_cooldown-=Time.deltaTime;
    }
	
	//used for dealing with physics stuff, anything that affects a rigidbody
	void FixedUpdate(){
		
		
	}
	
	void fire(){
		Debug.Log("pew, pew");
		//set it to instantiate further in front the player later
		Instantiate(projectile,transform.position,
			Quaternion.identity);
	}
	
}