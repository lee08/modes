using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topdown : MonoBehaviour {
	public float speed = 10.0f;
	public Rigidbody2D rb;
	public Vector2 movement;

	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
		rb.gravityScale = 0f;
	}
	void Awake(){
		rb = this.GetComponent<Rigidbody2D> ();
		rb.gravityScale = 0f;
	}
	// Update is called once per frame
	void Update () {
		movement = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
	}
	void FixedUpdate(){
		moveCharacter (movement);
	}
	void moveCharacter(Vector2 direction){
		rb.velocity = direction * speed;
	}
}
