using UnityEngine;
using System.Collections;

public class camera_control : MonoBehaviour {
	
	public StalkCamera stalk_camera;
	public FollowCamera follow_camera;
	public LookAtCamera look_at;
	
	float transform_cooldown = 3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Fire3")&&transform_cooldown>3){
			follow_camera.enabled = !follow_camera.enabled;
			stalk_camera.enabled = !stalk_camera.enabled;	
			transform_cooldown = 0;
		}
		
		transform_cooldown+=1*Time.deltaTime;
	}
}
