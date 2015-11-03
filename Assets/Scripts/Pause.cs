using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
	bool paused = false;
	
	public GameObject[] menu_items;
	
	//when pause put the items and menu background active
	//toggle on and off, paused and unpaused
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Escape))
		{
			paused = !paused;
			foreach(GameObject item in menu_items){
				item.SetActive(paused);
			}
		}

		if(paused){
			Time.timeScale = 0.25f;
			if (Input.GetKeyUp(KeyCode.Backspace)){
				Application.Quit();
				}
			}
		else{
			Time.timeScale = 1;
			}
	}
}
