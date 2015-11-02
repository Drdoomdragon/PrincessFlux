using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
	bool paused = false;
	
	//when pause put the items and menu background active
	//toggle on and off, paused and unpaused
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Escape))
		{
			paused = !paused;
		}

		if(paused){
			Time.timeScale = 0;
			if (Input.GetKeyUp(KeyCode.Backspace)){
				Application.Quit();
				}
			}
		else{
			Time.timeScale = 1;
			}
	}
}
