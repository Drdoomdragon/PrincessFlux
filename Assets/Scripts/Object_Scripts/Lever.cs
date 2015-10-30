using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour {
	
	Animator animator;
	
	public Sprite up;
	public Sprite down;
	SpriteRenderer spriteR;
	
	public bool active = false;
	public Door[] doors;
	bool close = false;
	
	float cooldown = 0f;
	
	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
		spriteR = GetComponent<SpriteRenderer>();
		if(spriteR.sprite == null)
			spriteR.sprite = up;
	}
	
	// Update is called once per frame
	void Update () {
		if(cooldown>1&&close&&Input.GetButtonDown("Fire1")){
			active=!active;
			StartCoroutine(ChangeSprite());
		}
		cooldown+=Time.deltaTime;
	}
	
	//call once player hits switch
	IEnumerator ChangeSprite(){
		if(spriteR.sprite == up){
			animator.Play("Pull_down");
			yield return new WaitForSeconds(1);
			spriteR.sprite = down;
		}
		else{
			animator.Play("Pull_up");
			yield return new WaitForSeconds(0.5f);
			spriteR.sprite = up;
		}
	}
	
	void OnTriggerStay2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			close = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			close = false;
		}
	}
}
