using UnityEngine;
using System.Collections;

public class load_L2 : MonoBehaviour {

void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
			Application.LoadLevel("Level_2");
		}
	}
}
