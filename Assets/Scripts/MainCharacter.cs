using UnityEngine;
using System.Collections;

public class MainCharacter : MonoBehaviour {

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2D;
    private float inverseMoveTime;
    private float speed;

    void Start () {
        boxCollider = GetComponent<BoxCollider2D>();
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
    }
}