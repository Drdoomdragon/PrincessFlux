using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	
	bool open = false;
	
	public Sprite opened;
	public Sprite closed;
	
	public Lever[] levers;
	
	int max;
	int pulled;
	SpriteRenderer spriteR;
	
	// Use this for initialization
	void Start () {
		spriteR = GetComponent<SpriteRenderer>();
		if(spriteR.sprite == null)
			spriteR.sprite = closed;
	}
	
	// Update is called once per frame
	void Update () {
		//when the door is open, the collider that previously blocked entry
		//becomes a trigger that allows the player to go to the next room
		if(open){
			this.GetComponent<Collider2D>().isTrigger = true;
		}
		else{
			this.GetComponent<Collider2D>().isTrigger = false;
		}
		
		foreach(Lever lever in levers){
			if (!lever.active){
				open = false;
				break;
			}
			else{
				open = false;
			}
		}
		
	}
	
	//call when door gets opened or closed
	void ChangeSprite(){
		if(spriteR.sprite == opened){
			spriteR.sprite = closed;
		}
		else{
			spriteR.sprite = opened;
		}
	}
	
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			//send the player to next room
		}
	}
	
}
