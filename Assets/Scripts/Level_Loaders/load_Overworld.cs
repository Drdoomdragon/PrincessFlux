using UnityEngine;
using System.Collections;

public class load_Overworld : MonoBehaviour {

void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Player"){
			Application.LoadLevel("Overworld");
		}
	}
}
