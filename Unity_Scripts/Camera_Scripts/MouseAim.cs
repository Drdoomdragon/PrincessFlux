using UnityEngine;
using System.Collections;

public class MouseAim : MonoBehaviour {
	
	public GameObject target;
	public float rotate_speed = 5f;
	public float damping = 1f;
	
	Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = target.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		float horizontal = Input.GetAxis("Mouse X") * rotate_speed;
		target.transform.Rotate(0,horizontal,0);
		
		float angle = target.transform.eulerAngles.y;
		float currentAngle = transform.eulerAngles.y;
		float finalAngle = Mathf.LerpAngle(currentAngle,angle,Time.deltaTime*damping);
		
		Quaternion rotation = Quaternion.Euler(0,finalAngle,0);
		transform.position = target.transform.position - (rotation * offset);
 
		transform.LookAt(target.transform);
	}
}
