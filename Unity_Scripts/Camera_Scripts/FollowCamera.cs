using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {
	
	public GameObject target;
	public float damping = 1f;
	Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = target.transform.position- transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		float angle = target.transform.eulerAngles.y;
		//float currentAngle = transform.eulerAngles.y;
		//float finalAngle = Mathf.LerpAngle(currentAngle,angle,Time.deltaTime*damping);
		
		Quaternion rotation = Quaternion.Euler(0,angle,0);
		transform.position = target.transform.position - (rotation*offset);
		
		transform.LookAt(target.transform);
	}
}
